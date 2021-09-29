using CashRegisterNStock.API.DTO.Products;
using System.Collections.Generic;

namespace CashRegisterNStock.API.DTO.TypeProducts
{
    public class TypeProductIndex
    {
        public string Name { get; set; }
        public List<ProductIndexDTO> ListProducts { get; set; }
    }
}
