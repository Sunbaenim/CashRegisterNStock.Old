using CashRegisterNStock.API.DTO.Products;
using CashRegisterNStock.API.DTO.Categories;
using CashRegisterNStock.DAL;
using CashRegisterNStock.DAL.Entities.Products;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ToolBox.AutoMapper.Mappers;

namespace CashRegisterNStock.API.Services
{
    public class CategoryService
    {
        private readonly CrnsDbContext dc;

        public CategoryService(CrnsDbContext dc)
        {
            this.dc = dc;
        }

        public void Create(CategoryAddDTO form)
        {
            dc.Categories.Add(form.MapTo<Category>());

            dc.SaveChanges();
        }

        public IEnumerable<CategoryIndexDTO> Read()
        {
            foreach (Category category in dc.Categories.Include(tp => tp.Products))
            {
                yield return new CategoryIndexDTO
                {
                    Id = category.Id,
                    Name = category.Name,
                    Products = category.Products.MapToList<ProductIndexDTO>().ToList()
                };
            }
        }

        public void Update(int id, CategoryUpdateDTO form)
        {
            Category category = dc.Categories.Find(id);
            form.MapToInstance<Category>(category);

            dc.SaveChanges();
        }

        public void Delete(int id)
        {
            dc.Categories.Remove(
                dc.Categories
                    .Where(tp => tp.Id == id)
                    .FirstOrDefault()
                );

            dc.SaveChanges();
        }
    }
}
