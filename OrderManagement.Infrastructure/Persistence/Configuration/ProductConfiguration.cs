using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.Persistence.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(200);

            builder.Property(p => p.Category).IsRequired().HasMaxLength(100);

            builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");

            builder.Property(p => p.StockQuantity).IsRequired();

            builder.Property(p => p.CreatedDate).IsRequired();
        }
    }
}
