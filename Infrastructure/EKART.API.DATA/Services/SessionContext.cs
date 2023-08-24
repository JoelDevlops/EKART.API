using Azure.Core;
using EKART.USER.CORE.Services.Others;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EKART.API.DATA.Services
{
    public class SessionContext : ISessionContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor; 
        }
        public Task<string> GetCurrentUser(CancellationToken cancellation)
        {
            string? authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            string jwtToken = authorizationHeader.Substring("Bearer ".Length).Trim();
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(jwtToken);

            // Extract the username claim from the JWT payload
            string username = token.Claims.FirstOrDefault(claim => claim.Type == "email")?.Value;

            return Task.FromResult(username);

        }
    }
}
