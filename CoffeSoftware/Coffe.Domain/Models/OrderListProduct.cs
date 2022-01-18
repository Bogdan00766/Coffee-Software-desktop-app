﻿using Coffe.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coffe.Domain.Models
{
    public class OrderListProduct
    {
        public int OrderListId { get; set; }
        public OrderList OrderList { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public OrderListProduct()
        {

        }

        public OrderListProduct(
            int orderListId,
            int productId
            )
        {
            OrderListId = orderListId;
            ProductId = productId;
        }
    }
}
