using CashRegisterNStock.API.DTO.Products;
using CashRegisterNStock.API.DTO.TypeProducts;
using CashRegisterNStock.DAL;
using CashRegisterNStock.DAL.Entities.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.AutoMapper.Mappers;

namespace CashRegisterNStock.API.Services
{
    public class TypeProductService
    {
        private readonly CrnsDbContext dc;

        public TypeProductService(CrnsDbContext dc)
        {
            this.dc = dc;
        }

        public void Create(TypeProductAddDTO form)
        {
            dc.TypeProducts.Add(form.MapTo<TypeProduct>());

            dc.SaveChanges();
        }

        public IEnumerable<TypeProductIndexDTO> Read()
        {
            TypeProduct typeProduct = dc.TypeProducts
                .Include(tp => tp.Products)
                .FirstOrDefault();

            yield return typeProduct.MapTo<TypeProductIndexDTO>(tp => tp.Products = typeProduct.Products.MapToList<ProductIndexDTO>().ToList());
        }

        public void Update(int id, TypeProductUpdateDTO form)
        {
            TypeProduct typeProduct = dc.TypeProducts.Find(id);
            form.MapToInstance<TypeProduct>(typeProduct);

            dc.SaveChanges();
        }

        public void Delete(int id)
        {
            dc.TypeProducts.Remove(
                dc.TypeProducts
                    .Where(tp => tp.Id == id)
                    .FirstOrDefault()
                );

            dc.SaveChanges();
        }
    }
}
