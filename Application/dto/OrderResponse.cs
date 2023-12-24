using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.dto
{
    public class OrderResponse
    {
        public Guid Id { get; set; }
        public double Total { get; set; }
        public StatusEnum Status { get; private set; }

        public ICollection<OrderProductResponse> Products { get; set; }

        public OrderResponse(Guid id, double total, StatusEnum status, List<OrderProductResponse> products) 
        {
            Id = id;
            Total = total;
            Status = status;
            Products = products;
        }

    }

    public class OrderProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; private set; }
        public int Quantity { get; set; }

        public OrderProductResponse(Guid id, string name, string description, double price, string imagePath, int quantity)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            ImagePath = imagePath;
            Quantity = quantity;
        }
    }
}
