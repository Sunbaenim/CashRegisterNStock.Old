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
            string filePath = "Assets/Products/" + form.Name + "-" + guid + "." + extensionFile;

            File.WriteAllBytes(filePath, base64);

            dc.Products.Add(new Product
            {
                CategoryId = form.CategoryId,
                Name = form.Name,
                ImageURL = extensionFile,
                Description = form.Description,
                Price = form.Price,
                Stock = form.Stock
            });

            dc.SaveChanges();
        }

        public IEnumerable<ProductIndexDTO> Read(int id)
        {
            return dc.Products
                .Where(p => p.Id == id)
                .MapToList<ProductIndexDTO>();
        }

        public ProductIndexDTO GetByName(ProductFilterDTO filter)
        {
            return dc.Products
                .Where(p => p.Name == filter.Name)
                .FirstOrDefault()
                .MapTo<ProductIndexDTO>();
        }

        public void Update(int id, ProductUpdateDTO form)
        {
            Product product = dc.Products
                .Where(p => p.Id == id)
                .FirstOrDefault();

            form.MapToInstance<Product>(product);

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
