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
    }
}
