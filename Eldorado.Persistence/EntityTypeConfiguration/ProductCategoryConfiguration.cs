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
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(pc => pc.Id);
            builder.Property(pc => pc.Name).IsRequired().HasMaxLength(50);

            builder
                .HasMany(pc => pc.Products)
                .WithOne(p => p.ProductCategory)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey(p => p.ProductCategoryId)
                .IsRequired(false);
        }
    }
}
