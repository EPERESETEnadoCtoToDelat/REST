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
    public class CourierConfiguration : IEntityTypeConfiguration<Courier>
    {
        public void Configure(EntityTypeBuilder<Courier> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Phone).IsRequired().HasMaxLength(11);
            builder.Property(c => c.PassportNumber).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Age).IsRequired().HasMaxLength(3);
            builder.Property(c => c.FullName).HasComputedColumnSql("FirstName || ' ' || LastName"); //SQLite
            //builder.Property(c => c.FullName).HasComputedColumnSql("FirstName + ' ' + LastName"); //MSSQl
            builder.HasCheckConstraint("CK_Age_Courier", "Age > 0 AND Age < 120");

            builder
                .HasMany(c => c.Orders)
                .WithOne(ofd => ofd.Courier)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(ofd => ofd.CourierId)
                .IsRequired(false);
        }
    }
}
