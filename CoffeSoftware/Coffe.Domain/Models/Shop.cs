using Coffe.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coffe.Domain.Models
{
    public class Shop : Entity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        public Shop()
        {

        }

        public Shop(string name)
        {
            Name = name;
        }
    }
}
