using CashRegisterNStock.API.DTO.Products;
using CashRegisterNStock.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CashRegisterNStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService pService;

        public ProductController(ProductService pService)
        {
            this.pService = pService;
        }

        [HttpGet]
        public IActionResult GetByName([FromQuery] ProductFilterDTO filter)
        {
            return Ok(pService.GetByName(filter));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(pService.Read(id));
        }

        [HttpPost]
        public IActionResult Post(ProductAddDTO form)
        {
            pService.Create(form);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ProductUpdateDTO form)
        {
            pService.Update(id, form);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)

        {
            pService.Delete(id);
            return NoContent();
        }
    }
}
