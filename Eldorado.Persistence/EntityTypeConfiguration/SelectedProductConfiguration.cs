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
    public class SelectedProductConfiguration : IEntityTypeConfiguration<SelectedProduct>
    {
        public void Configure(EntityTypeBuilder<SelectedProduct> builder)
        {
            builder.HasKey(sp => sp.Id);
            builder.Property(sp => sp.Count).IsRequired().HasDefaultValue(1);
            builder.Property(sp => sp.OrderId).IsRequired(false);
            builder.HasCheckConstraint("CK_Count_SP", "Count > 0 AND Count < 100");
        }
    }
}
