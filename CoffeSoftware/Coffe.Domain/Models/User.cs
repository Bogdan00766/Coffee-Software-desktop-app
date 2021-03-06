using Coffe.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coffe.Domain.Models
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public Address Address { get; set; }
        public List<Favorite> Favorites { get; set; }
        public List<OrderList> OrderLists { get; set; }
        public List<Payment> Payments { get; set; }

        public User()
        {

        }

        public User(string username, 
            string email, 
            string password, 
            bool isAdmin
           )
        {
            Username = username;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
        }
    }

}
