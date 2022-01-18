using Coffe.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coffe.Domain.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        public Category()
        {

        }

        public Category(
            string name, 
            List<Product> products)
        {
            Name = name;
            Products = products;
        }
    }
}
