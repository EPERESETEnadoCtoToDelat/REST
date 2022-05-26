﻿using Eldorado.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Persistence.EntityTypeConfiguration
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Price).IsRequired();

            builder
                .HasMany(c => c.SelectedProducts)
                .WithOne(sp => sp.Cart)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey(sp => sp.CartId)
                .IsRequired(false);
        }
    }
}
