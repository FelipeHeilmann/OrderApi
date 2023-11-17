using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;
using Domain.order.entitiy;
using Domain.product.entity;

namespace Domain.order.entity
{
    public class Order
    {
        public Guid Id { get; private set; }
        public List<OrderProduct> Products { get; private set; }
        public StatusEnum Status { get; private set; }
        public Double Total { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Order() { }
        
        public Order(Guid id, List<OrderProduct> products, StatusEnum status, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Products = products;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static Order Create()
        {
            return new Order(new Guid(), new List<OrderProduct>(), StatusEnum.created, new DateTime(), new DateTime());
        }

        public void AddItem(OrderProduct product)
        {
            Products.Add(product);
        }
    }
}
