namespace CashRegisterNStock.API.DTO.Auth
{
    public class TokenDTO
    {
        public TokenDTO(string token)
        {
            Token = token;
        }

        public string Token { get; set; }
    }
}
