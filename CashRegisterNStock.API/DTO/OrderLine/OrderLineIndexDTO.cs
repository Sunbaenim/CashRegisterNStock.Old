namespace CashRegisterNStock.API.DTO.OrderLine
{
    public class OrderLineIndexDTO
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
