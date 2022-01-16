using ToolBox.Security.Models;

namespace CashRegisterNStock.API.DTO.Auth
{
    public class TokenPayloadDTO : IBasePayload
    {
        public string Identifier { get; set; }
    }
}
