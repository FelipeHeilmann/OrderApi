using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;
using Domain.product.entity;

namespace Domain.Order.Entity
{
    public class Order
    {
        public Guid Id { get; private set; }
        public ICollection<Product> Products { get; private set; }
        public StatusEnum Status { get; private set; }
        public Double Total { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Order(Guid id, ICollection<Product> products, StatusEnum status, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Products = products;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static Order Create(ICollection<Product> products, StatusEnum status)
        {
            return new Order(new Guid(), products, status, new DateTime(), new DateTime());
        }
    }
}
