using System;

namespace Domain.product.entity
{
    public class Product
    {
        public Guid Id { get; private set; }
        public String Name { get; private set; }
        public String Description { get; private set; }
        public String ImagePath { get; private set; }
        public Double Price { get; private set; }

        public Product(Guid id, String name, String description, String imagePath, Double price)
        {
            Id = id;
            Name = name;
            Description = description;
            ImagePath = imagePath;
            Price = price;
        }

        public static Product Create(String name, String description, String imagePath, double price)
        {
            return new Product(new Guid(), name, description, imagePath, price);
        }

        public void Update(string description, string path, string name, double price)
        {
            Description = description;
            ImagePath = path;
            Price = price;
            Name = name;
        }
    }   
}
