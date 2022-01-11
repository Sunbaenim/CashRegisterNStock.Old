using CashRegisterNStock.API.DTO.Products;
using CashRegisterNStock.DAL;
using CashRegisterNStock.DAL.Entities.Products;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ToolBox.AutoMapper.Mappers;
using Microsoft.AspNetCore.Http;
using System;

namespace CashRegisterNStock.API.Services
{
    public class ProductService
    {
        private readonly CrnsDbContext dc;
        private readonly HttpContext ctx;

        public ProductService(CrnsDbContext dc, IHttpContextAccessor httpContext)
        {
            this.dc = dc;
            this.ctx = httpContext.HttpContext;
        }

        public void Create(ProductAddDTO form)
        {
            string extensionFile = form.ImageURL.Split("/", 3)[1].Split(";")[0];
            string base64String = form.ImageURL.Split(",")[1];
            byte[] base64 = Convert.FromBase64String(base64String);

            Guid guid = Guid.NewGuid();
            string filePath = "assets/products/" + form.Name + "-" + guid + "." + extensionFile;

            File.WriteAllBytes("wwwroot/" + filePath, base64);

            //string serverFilePath = ctx.Request.Scheme + "://" + ctx.Request.Host.Value + "/" + filePath;

            dc.Products.Add(new Product
            {
                CategoryId = form.CategoryId,
                Name = form.Name,
                ImageURL = filePath,
                Description = form.Description,
                Price = form.Price,
                Stock = form.Stock
            });

            dc.SaveChanges();
        }

        public IEnumerable<ProductIndexDTO> GetAll(ProductFilterDTO filter)
        {
            return dc.Products
                .Where(p => filter.Name == null || p.Name == filter.Name)
                .MapToList<ProductIndexDTO>();
        }

        public IEnumerable<ProductIndexDTO> GetByID(int id)
        {
            return dc.Products
                .Where(p => p.Id == id)
                .MapToList<ProductIndexDTO>();
        }

        public void Update(ProductUpdateDTO form)
        {
            Product product = dc.Products
                .Where(p => p.Id == form.Id)
                .FirstOrDefault();

            form.MapToInstance<Product>(product);

            dc.SaveChanges();
        }

        public void DecrementStock(ProductChangeStockDTO form)
        {
            Product product = dc.Products
                .Where(p => p.Id == form.Id)
                .FirstOrDefault();

            product.Stock -= form.Quantity;

            dc.SaveChanges();
        }

        public void Delete(int id)
        {
            dc.Products.Remove(
                dc.Products
                .Where(p => p.Id == id)
                .FirstOrDefault()
                );

            dc.SaveChanges();
        }
    }
}
