using CashRegisterNStock.API.DTO.Products;
using CashRegisterNStock.DAL;
using CashRegisterNStock.DAL.Entities.Products;
using System.Collections.Generic;
using System.Linq;
using ToolBox.AutoMapper.Mappers;

namespace CashRegisterNStock.API.Services
{
    public class ProductService
    {
        private readonly CrnsDbContext dc;

        public ProductService(CrnsDbContext dc)
        {
            this.dc = dc;
        }

        public void Create(ProductAddDTO form)
        {
            dc.Products.Add(form.MapTo<Product>());

            dc.SaveChanges();
        }

        public IEnumerable<ProductIndexDTO> Read(int productId)
        {
            return dc.Products
                .Where(p => p.TypeProductId == productId)
                .MapToList<ProductIndexDTO>();
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
