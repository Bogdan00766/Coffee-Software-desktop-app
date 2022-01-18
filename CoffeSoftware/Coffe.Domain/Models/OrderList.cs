using Coffe.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coffe.Domain.Models
{
    public class OrderList : Entity
    {
        public string Name { get; set; }
        public string CreationTime { get; set; }
        public User User { get; set; }
        public List<OrderListProduct> OrderListProducts { get; set; }

        public OrderList()
        {

        }

        public OrderList(string name, 
            string creationTime, 
            User user, 
            List<OrderListProduct> orderListProducts)
        {
            Name = name;
            CreationTime = creationTime;
            User = user;
            OrderListProducts = orderListProducts;
        }
    }
}
