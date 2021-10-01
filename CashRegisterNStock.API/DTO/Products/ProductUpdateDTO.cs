﻿using CashRegisterNStock.API.DTO.Validators;
using System.ComponentModel.DataAnnotations;

namespace CashRegisterNStock.API.DTO.Products
{
    public class ProductUpdateDTO
    {
        [Required]
        public int TypeProductId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Picture { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]
        [PositiveValidator]
        public decimal Price { get; set; }
        [Required]
        public int Stock { get; set; }
    }
}
