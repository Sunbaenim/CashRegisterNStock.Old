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
