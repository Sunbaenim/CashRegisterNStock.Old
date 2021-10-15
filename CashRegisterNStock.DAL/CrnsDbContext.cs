using CashRegisterNStock.DAL.Configurations;
using CashRegisterNStock.DAL.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace CashRegisterNStock.DAL
{
    public class CrnsDbContext : DbContext
    {
        public DbSet<TypeProduct> TypeProducts { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("server=DESKTOP-JHP2PQQ\\TB2019;initial catalog=CashRegisterNStockDB;integrated security=true");
            //optionsBuilder.UseSqlServer("server=SONIC-05;initial catalog=CashRegisterNStockDB;uid=sa;pwd=formation");
            optionsBuilder.UseSqlServer("workstation id=CashRegisterAndStock.mssql.somee.com;packet size=4096;user id=Kazekotei_SQLLogin_1;pwd=v7pvj3h46d;data source=CashRegisterAndStock.mssql.somee.com;persist security info=False;initial catalog=CashRegisterAndStock");
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.ApplyConfiguration(new TypeProductConfig());
            mb.ApplyConfiguration(new ProductConfig());
        }
    }
}
