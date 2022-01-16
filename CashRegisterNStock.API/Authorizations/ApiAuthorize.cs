using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Claims;

namespace CashRegisterNStock.API.Authorizations
{
    public class ApiAuthorize : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
           if((context.HttpContext.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value == null))
           {
                context.Result = new UnauthorizedResult();
           }
        }
    }
}
