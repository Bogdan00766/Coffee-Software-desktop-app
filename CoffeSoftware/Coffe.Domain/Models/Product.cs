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
        public string ImagePath { get; set; }
        public string Descriprion { get; set; }
        public string Brand { get; set; }
        public Category Category { get; set; }
        public Shop Shop { get; set; }
        public List<OrderListProduct> OrderListProducts { get; set; }

        public Product(string name, 
            float price, 
            string imagePath, 
            string descriprion, 
            string brand, 
            Category category, 
            Shop shop, 
            List<OrderListProduct> orderListProducts)
        {
            Name = name;
            Price = price;
            ImagePath = imagePath;
            Descriprion = descriprion;
            Brand = brand;
            Category = category;
            Shop = shop;
            OrderListProducts = orderListProducts;
        }
    }
}
