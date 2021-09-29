using System.ComponentModel.DataAnnotations;

namespace CashRegisterNStock.API.DTO.TypeProducts
{
    public class TypeProductAdd
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

    }
}
