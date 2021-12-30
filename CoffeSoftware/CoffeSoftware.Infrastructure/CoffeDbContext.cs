using Microsoft.EntityFrameworkCore;
using Coffe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coffe.Infrastructure
{
    public class CoffeDbContext : DbContext
    {
        public DbSet<Address> Address { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<OrderList> OrderList { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Shop> Shop { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<OrderListProduct> OrderListProduct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=shoppinglist.db");
        }

        //TODO OnModelCreating Have to add properties like .IsRequired to Name etc.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderListProduct>()
                .HasKey(olp => new { olp.OrderListId, olp.ProductId });
            modelBuilder.Entity<OrderListProduct>()
                .HasOne(olp => olp.OrderList)
                .WithMany(ol => ol.OrderListProducts)
                .HasForeignKey(olp => olp.OrderListId);
            modelBuilder.Entity<OrderListProduct>()
                .HasOne(olp => olp.Product)
                .WithMany(ol => ol.OrderListProducts)
                .HasForeignKey(olp => olp.ProductId);

        }

        
    }

}
