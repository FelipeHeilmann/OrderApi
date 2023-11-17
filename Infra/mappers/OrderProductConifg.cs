using Domain.order.entitiy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.mappers
{
    public class OrderProductConifg : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasKey(oderProduct => oderProduct.Id);
            builder.Property(oderProduct => oderProduct.Id).HasColumnName("id");
            builder.Property(oderProduct => oderProduct.OrderId).HasColumnName("order_id");
            builder.Property(oderProduct => oderProduct.ProductId).HasColumnName("product_id");
            builder.Property(oderProduct => oderProduct.ProductId).HasColumnName("product_id");

            builder.HasOne(oderProduct => oderProduct.Product);

            builder.ToTable("order_products");
        }
    }
}
