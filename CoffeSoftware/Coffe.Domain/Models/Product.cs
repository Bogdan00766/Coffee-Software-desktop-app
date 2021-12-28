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
        public List<OrderList> OrderLists { get; set; }
        public Category Category { get; set; }
        public Shop Shop { get; set; }
    }
}
