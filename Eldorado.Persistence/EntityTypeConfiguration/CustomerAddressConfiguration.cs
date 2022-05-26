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
    public class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.HasKey(ca => ca.Id);
            builder.Property(ca => ca.City).IsRequired().HasMaxLength(100);
            builder.Property(ca => ca.Street).IsRequired().HasMaxLength(100);
            builder.Property(ca => ca.House).IsRequired().HasMaxLength(10);
            builder.Property(ca => ca.Apartment).IsRequired().HasMaxLength(10);
        }
    }
}
