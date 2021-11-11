using CashRegisterNStock.API.DTO.Validators;
using System.ComponentModel.DataAnnotations;

namespace CashRegisterNStock.API.DTO.OrderLine
{
    public class OrderLineAddDTO
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        [PositiveValidator]
        public int Quantity { get; set; }
        [Required]
        [PositiveValidator]
        public decimal Price { get; set; }
    }
}
