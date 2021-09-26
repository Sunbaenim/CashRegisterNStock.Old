using System.ComponentModel.DataAnnotations;

namespace CashRegisterNStock.API.DTO.Validators
{
    public class PositiveValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return (decimal)value > 0;
        }
    }
}
