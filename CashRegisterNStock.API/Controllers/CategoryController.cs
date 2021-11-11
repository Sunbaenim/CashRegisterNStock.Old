using CashRegisterNStock.API.DTO.Categories;
using CashRegisterNStock.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CashRegisterNStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService tpService;

        public CategoryController(CategoryService tpService)
        {
            this.tpService = tpService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(tpService.Read());
        }

        [HttpPost]
        public IActionResult Post(CategoryAddDTO form)
        {
            tpService.Create(form);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, CategoryUpdateDTO form)
        {
            tpService.Update(id, form);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            tpService.Delete(id);
            return NoContent();
        }
    }
}
