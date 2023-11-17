using Domain.product.entity;
using System;
using System.Collections.Generic;
using System.Text;


namespace Domain.order.entitiy
{
    public class OrderProduct
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public OrderProduct() { }

        public OrderProduct(Guid id, Guid orderId, Guid prooductId, Product product, int quantity)
        {
            Id = id;
            OrderId = orderId;
            ProductId = prooductId;
            Product = product;
            Quantity = quantity;
        }

        public static OrderProduct Create(Guid orderId, Guid prooductId, Product product, int quantity)
        {
            return new OrderProduct(
                new Guid(),
                orderId,
                prooductId,
                product,
                quantity
            );
        }
    }
}
