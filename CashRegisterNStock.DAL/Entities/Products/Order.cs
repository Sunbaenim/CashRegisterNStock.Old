using CashRegisterNStock.DAL.Entities.Enums;
using System.Collections.Generic;

namespace CashRegisterNStock.DAL.Entities.Products
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderLine> OrderLine { get; set; }
        public Status Status { get; set; }
    }
}
