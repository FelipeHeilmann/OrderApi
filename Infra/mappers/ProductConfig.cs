using Domain.product.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.mappers
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.Id);
            builder.Property(product => product.Id).HasColumnName("id");
            builder.Property(product => product.Name).IsRequired().HasColumnName("name");
            builder.Property(product => product.Description).IsRequired().HasColumnName("description");
            builder.Property(product => product.Price).HasColumnName("price");
            builder.Property(product => product.ImagePath).HasColumnName("image_url");

            builder.ToTable("products");
        }
    }
}
