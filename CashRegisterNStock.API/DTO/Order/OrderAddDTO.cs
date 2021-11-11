using CashRegisterNStock.API.DTO.Enums;
using System.ComponentModel.DataAnnotations;

namespace CashRegisterNStock.API.DTO.Order
{
    public class OrderAddDTO
    {
        [Required]
        public StatusDTO Status { get; set; }
    }
}
