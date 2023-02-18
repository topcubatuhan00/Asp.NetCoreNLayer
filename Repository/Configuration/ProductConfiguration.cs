﻿using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).UseIdentityColumn();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Stock).IsRequired();
            builder.Property(c => c.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.ToTable("Products");

            // 1-m ilişkisinin kod hali. entity framework zaten hallediyor ama kodunu yazmakta iyi olur.
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);

        }
    }
}
