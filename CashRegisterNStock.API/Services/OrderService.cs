﻿using CashRegisterNStock.API.DTO.Order;
using CashRegisterNStock.DAL;
using CashRegisterNStock.DAL.Entities.Enums;
using CashRegisterNStock.DAL.Entities.Products;
using System.Collections.Generic;
using System.Linq;
using ToolBox.AutoMapper.Mappers;

namespace CashRegisterNStock.API.Services
{
    public class OrderService
    {
        private readonly CrnsDbContext dc;

        public OrderService(CrnsDbContext dc)
        {
            this.dc = dc;
        }

        public void Create(OrderAddDTO form)
        {
            dc.Order.Add(new Order {
                Status = (Status)form.Status
            });

            dc.SaveChanges();
        }

        public IEnumerable<OrderIndexDTO> GetAll()
        {
            return dc.Order
                .MapToList<OrderIndexDTO>();
        }

        public OrderIndexDTO GetById(int id)
        {
            return dc.Order
                .Where(o => o.Id == id)
                .FirstOrDefault()
                .MapTo<OrderIndexDTO>();
        }

        public void Update(int id, OrderAddDTO form)
        {
            Order order = dc.Order
                .Where(o => o.Id == id)
                .FirstOrDefault();

            form.MapToInstance<Order>(order);

            dc.SaveChanges();
        }
    }
}
