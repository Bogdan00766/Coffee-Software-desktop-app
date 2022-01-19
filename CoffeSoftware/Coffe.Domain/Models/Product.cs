using Coffe.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coffe.Domain.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public byte[] ImagePath { get; set; }
        public Category Category { get; set; }
        public Shop Shop { get; set; }
        public List<OrderListProduct> OrderListProducts { get; set; }

        public Product()
        {

        }

        public Product(
            string name, 
            float price, 
            byte[] imagePath )
        {
            Name = name;
            Price = price;
            ImagePath = imagePath;
        }
    }
}
