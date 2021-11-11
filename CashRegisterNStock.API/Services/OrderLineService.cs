using CashRegisterNStock.API.DTO.OrderLine;
using CashRegisterNStock.DAL;
using CashRegisterNStock.DAL.Entities.Products;
using System.Collections.Generic;
using System.Linq;
using ToolBox.AutoMapper.Mappers;

namespace CashRegisterNStock.API.Services
{
    public class OrderLineService
    {
        private readonly CrnsDbContext dc;

        public OrderLineService(CrnsDbContext dc)
        {
            this.dc = dc;
        }

        public void Create(OrderLineAddDTO form)
        {
            dc.OrderLine.Add(new OrderLine {
                OrderId = form.OrderId,
                ProductId = form.ProductId,
                Price = form.Price,
                Quantity = form.Quantity
            });
            dc.SaveChanges();
        }

        public IEnumerable<OrderLineIndexDTO> GetAll()
        {
            return dc.OrderLine
                .MapToList<OrderLineIndexDTO>();
        }

        public OrderLineIndexDTO GetById(int orderId, int productId)
        {
            return dc.OrderLine
                .Where(ol => ol.OrderId == orderId && ol.ProductId == productId)
                .FirstOrDefault()
                .MapTo<OrderLineIndexDTO>();
        }

        public void Update(int orderId, int productId, OrderLineAddDTO form)
        {
            OrderLine orderLine = dc.OrderLine
                .Where(ol => ol.OrderId == orderId && ol.ProductId == productId)
                .FirstOrDefault();

            form.MapToInstance<OrderLine>(orderLine);

            dc.SaveChanges();
        }
    }
}
