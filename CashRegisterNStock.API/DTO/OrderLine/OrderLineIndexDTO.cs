using CashRegisterNStock.API.DTO.Order;
using CashRegisterNStock.API.DTO.Products;

namespace CashRegisterNStock.API.DTO.OrderLine
{
    public class OrderLineIndexDTO
    {
        public OrderIndexDTO Order { get; set; }
        public ProductIndexDTO Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
