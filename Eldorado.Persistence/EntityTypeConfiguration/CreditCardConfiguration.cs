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
    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasKey(cc => cc.Id);
            builder.Property(cc => cc.Number).IsRequired().HasMaxLength(16).IsFixedLength();
            builder.Property(cc => cc.EndDate).IsRequired();
            builder.Property(cc => cc.CVV2).IsRequired().HasMaxLength(3).IsFixedLength();
            builder.Property(cc => cc.OwnerName).IsRequired().HasMaxLength(50);
            builder.HasIndex(cc => cc.Number).IsUnique();
        }
    }
}
