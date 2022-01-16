using CashRegisterNStock.API.Authorizations;
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
        [ApiAuthorize]
        public IActionResult Post(CategoryAddDTO form)
        {
            tpService.Create(form);
            return NoContent();
        }

        [HttpPut]
        [ApiAuthorize]
        public IActionResult Put(CategoryUpdateDTO form)
        {
            tpService.Update(form);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ApiAuthorize]
        public IActionResult Delete(int id)
        {
            tpService.Delete(id);
            return NoContent();
        }
    }
}
