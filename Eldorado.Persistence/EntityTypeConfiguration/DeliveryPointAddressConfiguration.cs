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
    public class DeliveryPointAddressConfiguration : IEntityTypeConfiguration<DeliveryPointAddress>
    {
        public void Configure(EntityTypeBuilder<DeliveryPointAddress> builder)
        {
            builder.HasKey(dpa => dpa.Id);
            builder.Property(dpa => dpa.Street).IsRequired().HasMaxLength(50);
            builder.Property(dpa => dpa.City).IsRequired().HasMaxLength(50);
            builder.Property(dpa => dpa.House).IsRequired().HasMaxLength(10);
        }
    }
}
