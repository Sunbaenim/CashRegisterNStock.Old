﻿// <auto-generated />
using System;
using CashRegisterNStock.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CashRegisterNStock.DAL.Migrations
{
    [DbContext(typeof(CrnsDbContext))]
    partial class CrnsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CashRegisterNStock.DAL.Entities.Auth.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Password")
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("Salt")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = new byte[] { 195, 18, 7, 130, 82, 113, 144, 133, 20, 81, 45, 138, 184, 74, 204, 160, 139, 147, 28, 231, 23, 84, 187, 7, 11, 111, 25, 172, 109, 63, 34, 188, 177, 135, 160, 9, 120, 87, 40, 56, 236, 144, 152, 129, 153, 37, 230, 182, 213, 83, 8, 69, 126, 251, 179, 66, 65, 167, 251, 35, 129, 151, 120, 170 },
                            Salt = new Guid("a0518924-719e-4772-950d-d1c12aba4497"),
                            Username = "Admin"
                        });
                });

            modelBuilder.Entity("CashRegisterNStock.DAL.Entities.Products.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CashRegisterNStock.DAL.Entities.Products.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("CashRegisterNStock.DAL.Entities.Products.OrderLine", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderLine");
                });

            modelBuilder.Entity("CashRegisterNStock.DAL.Entities.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CashRegisterNStock.DAL.Entities.Products.OrderLine", b =>
                {
                    b.HasOne("CashRegisterNStock.DAL.Entities.Products.Order", "Order")
                        .WithMany("OrderLine")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CashRegisterNStock.DAL.Entities.Products.Product", "Product")
                        .WithMany("OrderLine")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CashRegisterNStock.DAL.Entities.Products.Product", b =>
                {
                    b.HasOne("CashRegisterNStock.DAL.Entities.Products.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CashRegisterNStock.DAL.Entities.Products.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("CashRegisterNStock.DAL.Entities.Products.Order", b =>
                {
                    b.Navigation("OrderLine");
                });

            modelBuilder.Entity("CashRegisterNStock.DAL.Entities.Products.Product", b =>
                {
                    b.Navigation("OrderLine");
                });
#pragma warning restore 612, 618
        }
    }
}
