using CashRegisterNStock.API.DTO.Order;
using CashRegisterNStock.API.DTO.OrderLine;
using CashRegisterNStock.API.DTO.Products;
using CashRegisterNStock.DAL;
using CashRegisterNStock.DAL.Entities.Products;
using Microsoft.EntityFrameworkCore;
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
            foreach (OrderLine orderLine in dc.OrderLine.Include(ol => ol.Order).Include(ol => ol.Product))
            {
                yield return new OrderLineIndexDTO
                {
                    Order = orderLine.Order.MapTo<OrderIndexDTO>(),
                    Product = orderLine.Product.MapTo<ProductIndexDTO>(),
                    Quantity = orderLine.Quantity,
                    Price = orderLine.Price
                };
            }
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

        public void Delete(int orderId, int productId)
        {
            dc.OrderLine.Remove(
                dc.OrderLine
                .Where(ol => ol.OrderId == orderId && ol.ProductId == productId)
                .FirstOrDefault()
                );

            dc.SaveChanges();
        }
    }
}
