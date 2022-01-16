using CashRegisterNStock.API.DTO.Auth;
using CashRegisterNStock.API.Exceptions;
using CashRegisterNStock.DAL;
using CashRegisterNStock.DAL.Entities.Auth;
using System;
using System.Linq;
using ToolBox.Security.Hash;

namespace CashRegisterNStock.API.Services
{
    public class AuthService
    {
        private readonly CrnsDbContext _dc;
        private readonly HashService _service;

        public AuthService(CrnsDbContext dc, HashService service)
        {
            _dc = dc;
            _service = service;
        }

        public TokenPayloadDTO GetByUsernameAndPassword(LoginDTO dto)
        {
            User u = _dc.Users.FirstOrDefault(u => u.Username == dto.Username);
            if (u is null)
            {
                throw new NotFoundException();
            }
            if(!_service.Compare(dto.Password + u.Salt.ToString(), u.Password)) 
            {
                throw new NotFoundException();
            }
            return new TokenPayloadDTO { Identifier = u.Username };
        }
    }
}
