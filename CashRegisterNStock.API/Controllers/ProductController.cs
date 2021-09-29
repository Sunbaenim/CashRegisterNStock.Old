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
        public IActionResult GetProducts()
        {
            //return Ok(pService.Read());
            return StatusCode(501);
        }

        [HttpPost]
        public IActionResult AddProduct(ProductAddDTO form)
        {
            pService.Create(form);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, ProductUpdateDTO form)
        {
            pService.Update(id, form);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            pService.Delete(id);
            return NoContent();
        }
    }
}
