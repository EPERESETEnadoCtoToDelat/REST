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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Date).IsRequired();
            builder.Property(o => o.Price).IsRequired().HasMaxLength(50);

            builder
                .HasMany(o => o.SelectedProducts)
                .WithOne(sp => sp.Order)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(sp => sp.OrderId)
                .IsRequired();
        }
    }
}
