using CashRegisterNStock.DAL.Configurations.Products;
using CashRegisterNStock.DAL.Entities.Auth;
using CashRegisterNStock.DAL.Entities.Products;
using Microsoft.EntityFrameworkCore;
using ToolBox.Security.Hash;
using System.Security.Cryptography;
using System;

namespace CashRegisterNStock.DAL
{
    public class CrnsDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderLine> OrderLine { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("server=DESKTOP-1HNCA4J\\TB2021;initial catalog=CRNS_DB;integrated security=true");
            //optionsBuilder.UseSqlServer("server=SONIC-05;initial catalog=CashRegisterNStockDB;uid=sa;pwd=formation");
            optionsBuilder.UseSqlServer("workstation id=CRNS-Database.mssql.somee.com;packet size=4096;user id=Kazekotei_SQLLogin_1;pwd=v7pvj3h46d;data source=CRNS-Database.mssql.somee.com;persist security info=False;initial catalog=CRNS-Database");
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.ApplyConfiguration(new CategoryConfig());
            mb.ApplyConfiguration(new ProductConfig());
            mb.ApplyConfiguration(new OrderConfig());
            mb.ApplyConfiguration(new OrderLineConfig());

            HashService hS = new HashService(new SHA512CryptoServiceProvider());
            Guid salt = Guid.NewGuid();
            byte[] encodedPwd = hS.Hash("admin" + salt.ToString());

            mb.Entity<User>().HasData(new User { Id = 1, Username = "Admin", Salt = salt, Password = encodedPwd }); ;
        }
    }
}
