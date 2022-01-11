﻿using CashRegisterNStock.API.DTO.OrderLine;
using CashRegisterNStock.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CashRegisterNStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderLineController : ControllerBase
    {
        private readonly OrderLineService _olService;

        public OrderLineController(OrderLineService oService)
        {
            _olService = oService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_olService.GetAll());
        }

        [HttpGet("{orderId}")]
        public IActionResult GetAllByOrderId(int orderId)
        {
            return Ok(_olService.GetAllByOrderId(orderId));
        }

        [HttpGet("{orderId}, {productId}")]
        public IActionResult GetById(int orderId, int productId)
        {
            return Ok(_olService.GetById(orderId, productId));
        }

        [HttpPost]
        public IActionResult Post(OrderLineAddDTO form)
        {
            _olService.Create(form);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Put(OrderLineAddDTO form)
        {
            _olService.Update(form);
            return NoContent();
        }

        [HttpDelete("{orderId}, {productId}")]
        public IActionResult Delete(int orderId, int productId)
        {
            _olService.Delete(orderId, productId);
            return NoContent();
        }
    }
}
