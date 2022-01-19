using Coffe.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coffe.Domain.Models
{
    public class Favorite : Entity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public Favorite()
        {

        }

        public Favorite(
            int userId,
            int productId
            )
        {
            UserId = userId;
            ProductId = productId;
        }
    }
}
