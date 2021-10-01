using CashRegisterNStock.API.DTO.TypeProducts;
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
    public class TypeProductController : ControllerBase
    {
        private readonly TypeProductService tpService;

        public TypeProductController(TypeProductService tpService)
        {
            this.tpService = tpService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(tpService.Read());
        }

        [HttpPost]
        public IActionResult Post(TypeProductAddDTO form)
        {
            tpService.Create(form);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TypeProductUpdateDTO form)
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
