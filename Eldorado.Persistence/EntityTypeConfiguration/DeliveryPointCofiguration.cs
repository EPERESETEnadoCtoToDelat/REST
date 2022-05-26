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
    public class DeliveryPointCofiguration : IEntityTypeConfiguration<DeliveryPoint>
    {
        public void Configure(EntityTypeBuilder<DeliveryPoint> builder)
        {
            builder.HasKey(dp => dp.Id);
            builder.Property(dp => dp.WorkingTime).IsRequired();

            builder
                .HasMany(dp => dp.Orders)
                .WithOne(o => o.DeliveryPoint)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey(o => o.DeliveryPointId)
                .IsRequired(false);

            builder
                .HasOne(dp => dp.DeliveryPointAddress)
                .WithOne(dpa => dpa.DeliveryPoint)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey<DeliveryPointAddress>(dpa => dpa.DeliveryPointId)
                .IsRequired();
        }
    }
}
