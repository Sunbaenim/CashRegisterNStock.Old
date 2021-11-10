using CashRegisterNStock.API.DTO.Products;
using CashRegisterNStock.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
