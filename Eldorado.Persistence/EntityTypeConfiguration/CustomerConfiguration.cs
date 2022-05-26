using Eldorado.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Persistence.EntityTypeConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Phone).IsRequired().HasMaxLength(11);
            builder.Property(c => c.Age).IsRequired().HasDefaultValue(18);
            //builder.Property(c => c.FullName).HasComputedColumnSql("FirstName + ' ' + LastName"); //MSSQL
            builder.Property(c => c.FullName).HasComputedColumnSql("FirstName || ' ' || LastName"); //SQLite
            builder.HasAlternateKey(c => c.Phone);
            builder.HasAlternateKey(c => c.Email);
            builder.HasCheckConstraint("CK_Age_Customer", "Age > 0 AND Age < 120");

            builder
                .HasOne(c => c.CustomerAddress)
                .WithOne(ca => ca.Customer)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey<CustomerAddress>(ca => ca.CustomerId)
                .IsRequired();

            builder
                .HasMany(c => c.CreditCards)
                .WithOne(cc => cc.Customer)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(cc => cc.CustomerId)
                .IsRequired(false);

            builder
                .HasOne(c => c.Cart)
                .WithOne(cart => cart.Customer)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey<Cart>(cart => cart.CustomerId)
                .IsRequired();

            builder
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(o => o.CustomerId)
                .IsRequired(false);
        }
    }
}
