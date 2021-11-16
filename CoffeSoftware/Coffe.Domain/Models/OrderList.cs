using Coffe.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coffe.Domain.Models
{
    class OrderList : Entity
    {
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
