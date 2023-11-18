﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shopping_list_website.Models;

#nullable disable

namespace Shopping_list_website.Migrations
{
    [DbContext(typeof(ShoppingCartDbContext))]
    [Migration("20231108014716_addedQuantity")]
    partial class addedQuantity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Shopping_list_website.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SelectedCart")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "a",
                            Password = "$2a$11$ABbq59Co.d9iEVFXWU83MeDxNC4Gh3UXIaT.59Yhu1B/WeqYPsxG6"
                        },
                        new
                        {
                            Id = 2,
                            Email = "websiteman@mail.com",
                            Password = "$2a$11$2Vwo/d3cm2TJ2WcBEHX8bu2E2TZ3DT3iL.0uv3CLB01EcQD9fI8EO"
                        });
                });

            modelBuilder.Entity("Shopping_list_website.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Granny Smith Apples",
                            Price = 5.50m,
                            Unit = "1kg"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Fresh tomatoes",
                            Price = 5.90m,
                            Unit = "500g"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Watermelon",
                            Price = 6.60m,
                            Unit = "Whole"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Cucumber",
                            Price = 1.90m,
                            Unit = "1 whole"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Red potato washed",
                            Price = 4.00m,
                            Unit = "1kg"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Red tipped bananas",
                            Price = 4.90m,
                            Unit = "1kg"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Red onion",
                            Price = 3.50m,
                            Unit = "1kg"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Carrots",
                            Price = 2.00m,
                            Unit = "1kg"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Iceburg Lettuce",
                            Price = 2.50m,
                            Unit = "1"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Helga's Wholemeal",
                            Price = 3.70m,
                            Unit = "1"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Free range chicken",
                            Price = 7.50m,
                            Unit = "1kg"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Manning Valley 6-pk",
                            Price = 3.60m,
                            Unit = "6 eggs"
                        },
                        new
                        {
                            Id = 13,
                            Name = "A2 light milk",
                            Price = 2.90m,
                            Unit = "1 litre"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Chobani Strawberry Yoghurt",
                            Price = 1.50m,
                            Unit = "1"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Lurpak Salted Blend",
                            Price = 5.00m,
                            Unit = "250g"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Bega Farmers Tasty",
                            Price = 4.00m,
                            Unit = "250g"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Babybel Mini",
                            Price = 4.20m,
                            Unit = "100g"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Cobram EVOO",
                            Price = 8.00m,
                            Unit = "375ml"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Heinz Tomato Soup",
                            Price = 2.50m,
                            Unit = "535g"
                        },
                        new
                        {
                            Id = 20,
                            Name = "John West Tuna can",
                            Price = 1.50m,
                            Unit = "95g"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Cadbury Dairy Milk",
                            Price = 5.00m,
                            Unit = "200g"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Coca Cola",
                            Price = 2.85m,
                            Unit = "2 litre"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Smith's Original Share Pack Crisps",
                            Price = 3.29m,
                            Unit = "170g"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Birds Eye Fish Fingers",
                            Price = 4.50m,
                            Unit = "375g"
                        },
                        new
                        {
                            Id = 25,
                            Name = "Berri Orange Juice",
                            Price = 6.00m,
                            Unit = "2 litre"
                        },
                        new
                        {
                            Id = 26,
                            Name = "Vegemite",
                            Price = 6.00m,
                            Unit = "380g"
                        },
                        new
                        {
                            Id = 27,
                            Name = "Cheddar Shapes",
                            Price = 2.00m,
                            Unit = "175g"
                        },
                        new
                        {
                            Id = 28,
                            Name = "Colgate Total Toothpaste Original",
                            Price = 3.50m,
                            Unit = "110g"
                        },
                        new
                        {
                            Id = 29,
                            Name = "Milo Chocolate Malt",
                            Price = 4.00m,
                            Unit = "200g"
                        },
                        new
                        {
                            Id = 30,
                            Name = "Weet Bix Saniatarium Organic",
                            Price = 5.33m,
                            Unit = "750g"
                        },
                        new
                        {
                            Id = 31,
                            Name = "Lindt Excellence 70% Cocoa Block",
                            Price = 4.25m,
                            Unit = "100g"
                        },
                        new
                        {
                            Id = 32,
                            Name = "Original Tim Tams Choclate",
                            Price = 3.65m,
                            Unit = "200g"
                        },
                        new
                        {
                            Id = 33,
                            Name = "Philadelphia Original Cream Cheese",
                            Price = 4.30m,
                            Unit = "250g"
                        },
                        new
                        {
                            Id = 34,
                            Name = "Moccana Classic Instant Medium Roast",
                            Price = 6.00m,
                            Unit = "100g"
                        },
                        new
                        {
                            Id = 35,
                            Name = "Capilano Squeezable Honey",
                            Price = 7.35m,
                            Unit = "500g"
                        },
                        new
                        {
                            Id = 36,
                            Name = "Nutella jar",
                            Price = 4.00m,
                            Unit = "400g"
                        },
                        new
                        {
                            Id = 37,
                            Name = "Arnott's Scotch Finger",
                            Price = 2.85m,
                            Unit = "250g"
                        },
                        new
                        {
                            Id = 38,
                            Name = "South Cape Greek Feta",
                            Price = 5.00m,
                            Unit = "200g"
                        },
                        new
                        {
                            Id = 39,
                            Name = "Sacla Pasta Tomato Basil Sauce",
                            Price = 3.00m,
                            Unit = "420g"
                        },
                        new
                        {
                            Id = 40,
                            Name = "Primo English Ham",
                            Price = 3.00m,
                            Unit = "100g"
                        },
                        new
                        {
                            Id = 41,
                            Name = "Primo Short cut rindless Bacon",
                            Price = 5.00m,
                            Unit = "175g"
                        },
                        new
                        {
                            Id = 42,
                            Name = "Golden Circle Pineapple Pieces in natural juice",
                            Price = 3.25m,
                            Unit = "440g"
                        },
                        new
                        {
                            Id = 43,
                            Name = "San Remo Linguine Pasta No 1",
                            Price = 1.95m,
                            Unit = "500g"
                        });
                });

            modelBuilder.Entity("Shopping_list_website.Models.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("Shopping_list_website.Models.ShoppingCartLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("ShoppingCartId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("ShoppingCartLines");
                });

            modelBuilder.Entity("Shopping_list_website.Models.ShoppingCart", b =>
                {
                    b.HasOne("Shopping_list_website.Models.Account", "Account")
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Shopping_list_website.Models.ShoppingCartLine", b =>
                {
                    b.HasOne("Shopping_list_website.Models.Item", "Item")
                        .WithMany("ShoppingCartLines")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shopping_list_website.Models.ShoppingCart", "ShoppingCart")
                        .WithMany("Lines")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("Shopping_list_website.Models.Account", b =>
                {
                    b.Navigation("ShoppingCarts");
                });

            modelBuilder.Entity("Shopping_list_website.Models.Item", b =>
                {
                    b.Navigation("ShoppingCartLines");
                });

            modelBuilder.Entity("Shopping_list_website.Models.ShoppingCart", b =>
                {
                    b.Navigation("Lines");
                });
#pragma warning restore 612, 618
        }
    }
}
