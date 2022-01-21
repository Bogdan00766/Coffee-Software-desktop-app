﻿// <auto-generated />
using System;
using Coffe.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Coffe.Infrastructure.Migrations
{
    [DbContext(typeof(CoffeDbContext))]
    [Migration("20220121163730_mig7")]
    partial class mig7
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Coffe.Domain.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<int>("PostalCode");

                    b.Property<string>("State");

                    b.Property<string>("Street");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Coffe.Domain.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Coffe.Domain.Models.Favorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProductId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Favorite");
                });

            modelBuilder.Entity("Coffe.Domain.Models.OrderList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreationTime");

                    b.Property<string>("Name");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("OrderList");
                });

            modelBuilder.Entity("Coffe.Domain.Models.OrderListProduct", b =>
                {
                    b.Property<int>("OrderListId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("OrderListId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderListProduct");
                });

            modelBuilder.Entity("Coffe.Domain.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CVV");

                    b.Property<string>("CardName");

                    b.Property<int>("CardNumber");

                    b.Property<int>("Sum");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Coffe.Domain.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<byte[]>("ImagePath");

                    b.Property<string>("Name");

                    b.Property<float>("Price");

                    b.Property<int?>("ShopId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ShopId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Coffe.Domain.Models.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("ImagePath");

                    b.Property<string>("Name");

                    b.Property<float>("Price");

                    b.HasKey("Id");

                    b.ToTable("Shop");
                });

            modelBuilder.Entity("Coffe.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddressId");

                    b.Property<string>("Email");

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Coffe.Domain.Models.Favorite", b =>
                {
                    b.HasOne("Coffe.Domain.Models.Product", "Product")
                        .WithMany("Favorites")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Coffe.Domain.Models.User", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Coffe.Domain.Models.OrderList", b =>
                {
                    b.HasOne("Coffe.Domain.Models.User", "User")
                        .WithMany("OrderLists")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Coffe.Domain.Models.OrderListProduct", b =>
                {
                    b.HasOne("Coffe.Domain.Models.OrderList", "OrderList")
                        .WithMany("OrderListProducts")
                        .HasForeignKey("OrderListId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Coffe.Domain.Models.Product", "Product")
                        .WithMany("OrderListProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Coffe.Domain.Models.Payment", b =>
                {
                    b.HasOne("Coffe.Domain.Models.User", "User")
                        .WithMany("Payments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Coffe.Domain.Models.Product", b =>
                {
                    b.HasOne("Coffe.Domain.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.HasOne("Coffe.Domain.Models.Shop", "Shop")
                        .WithMany("Products")
                        .HasForeignKey("ShopId");
                });

            modelBuilder.Entity("Coffe.Domain.Models.User", b =>
                {
                    b.HasOne("Coffe.Domain.Models.Address", "Address")
                        .WithMany("Users")
                        .HasForeignKey("AddressId");
                });
#pragma warning restore 612, 618
        }
    }
}
