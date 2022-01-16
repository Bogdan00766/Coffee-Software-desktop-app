using Coffe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coffe.Domain
{
    public static class CurrentUser
    {
        public static int Id { get; set; }
        public static string Username { get; set; }
        public static string Email { get; set; }
        public static string Password { get; set; }
        public static bool IsAdmin { get; set; }
        public static Address Address { get; set; }
        public static List<OrderList> OrderLists { get; set; }
        public static bool isGuest = true;

        public static void Login(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Email = user.Email;
            Password = user.Password;
            IsAdmin = user.IsAdmin;
            Address = user.Address;
            OrderLists = user.OrderLists;
            isGuest = false;
        }

        public static void Logout()
        {
            Id = -1;
            isGuest = true;
            Username = null;
            Email = null;
            Password = null;
            IsAdmin = false;
            Address = null;
            OrderLists = null;
        }
    }
}
