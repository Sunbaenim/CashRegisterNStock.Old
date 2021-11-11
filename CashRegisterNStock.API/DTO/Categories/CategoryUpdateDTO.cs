using System.ComponentModel.DataAnnotations;

namespace CashRegisterNStock.API.DTO.Categories
{
    public class CategoryUpdateDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
