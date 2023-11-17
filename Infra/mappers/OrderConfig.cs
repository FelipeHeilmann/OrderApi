using Domain.order.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.mappers
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(order => order.Id);
            builder.Property(order => order.Id).HasColumnName("id");
            builder.Property(order => order.Status).HasColumnName("status");
            builder.Property(order => order.Total).HasColumnName("total");
            builder.Property(order => order.CreatedAt).HasColumnName("created_at");
            builder.Property(order => order.UpdatedAt).HasColumnName("updated_at");

            builder.ToTable("orders");

            builder.
                HasMany(order => order.Products)
                .WithOne()
                .HasForeignKey(orderProduct => orderProduct.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
