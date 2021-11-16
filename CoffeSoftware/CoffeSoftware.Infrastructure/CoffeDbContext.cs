using Microsoft.EntityFrameworkCore;
using Coffe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coffe.Infrastructure
{
    class CoffeDbContext : DbContext
    {
        public DbSet<Address> Address { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<OrderList> OrderList { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Shop> Shop { get; set; }
        public DbSet<User> User { get; set; }
    }
}
