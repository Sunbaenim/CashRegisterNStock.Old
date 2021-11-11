using CashRegisterNStock.API.DTO.Order;
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
    public class OrderController : ControllerBase
    {
        private readonly OrderService _oService;

        public OrderController(OrderService oService)
        {
            _oService = oService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_oService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_oService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post(OrderAddDTO form)
        {
            _oService.Create(form);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, OrderAddDTO form)
        {
            _oService.Update(id, form);
            return NoContent();
        }
    }
}
