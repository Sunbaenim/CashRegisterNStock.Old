using CashRegisterNStock.API.DTO.Products;
using System.Collections.Generic;

namespace CashRegisterNStock.API.DTO.TypeProducts
{
    public class TypeProductIndexDTO
    {
        public string Name { get; set; }
        public List<ProductIndexDTO> Products { get; set; }
    }
}
