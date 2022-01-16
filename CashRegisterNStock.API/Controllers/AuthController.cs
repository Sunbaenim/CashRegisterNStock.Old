using CashRegisterNStock.API.DTO.Auth;
using CashRegisterNStock.API.Exceptions;
using CashRegisterNStock.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToolBox.Security.Services;

namespace CashRegisterNStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly JwtService _jwtService;

        public AuthController(AuthService authService, JwtService jwtService)
        {
            _authService = authService;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO dto)
        {
            try
            {
                TokenPayloadDTO payload = _authService.GetByUsernameAndPassword(dto);
                return Ok(new TokenDTO(_jwtService.CreateToken(payload)));
            }
            catch (NotFoundException)
            {
                return BadRequest("Invalid credentials");
            }
        }
    }
}
