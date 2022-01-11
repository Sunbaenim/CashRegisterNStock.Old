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
        public IActionResult Get([FromQuery] ProductFilterDTO filter)
        {
            return Ok(pService.GetAll(filter));
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            return Ok(pService.GetByID(id));
        }

        [HttpPost]
        public IActionResult Post(ProductAddDTO form)
        {
            pService.Create(form);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Put(ProductUpdateDTO form)
        {
            pService.Update(form);
            return NoContent();
        }

        [HttpPut]
        [Route("Stock")]
        public IActionResult DecrementStock(ProductChangeStockDTO form)
        {
            pService.DecrementStock(form);
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
