using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Security.Services;

namespace ToolBox.Security.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;


        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task InvokeAsync(HttpContext context, JwtService jwtService)
        {
            try
            {
                string token = context.Request.Headers.FirstOrDefault(h => h.Key == "Authorization").Value.FirstOrDefault()?.Replace("Bearer ", "");
                ClaimsPrincipal p = jwtService.GetClaims(token);
                if(p != null)
                {
                    context.User = p;
                }
            }
            catch (Exception ex)
            {

            }
            await _next(context);
        }
    }
}
