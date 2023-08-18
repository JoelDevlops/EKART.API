using EKART.USER.CORE.Services.Others;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EKART.API.SERVICES.Services
{
    public class TokenServicecs : ITokenGenerator
    {
        private IConfiguration configuration;
        public TokenServicecs(IConfiguration configuration) 
        {
        this.configuration = configuration;
        }

      

        public async Task<string> GenerateJWTToken(string username, CancellationToken cancellation)
        {
            try
            {
                var issuer = configuration["Jwt:Issuer"];
                var audience = configuration["Jwt:Audience"];
                var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]);
                int expiry = int.Parse(configuration["Jwt:TokenValidityInMinutes"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Email, username),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
             }),
                    Expires = DateTime.UtcNow.AddMinutes(expiry),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch 
            {
                throw;
            }
          
        }

        public async Task<string> GenerateRefreshToken(CancellationToken cancellation)
        {
            var randonNumber = new byte[32];
            using(var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randonNumber);
                return Convert.ToBase64String(randonNumber);
            }
        }
    }
}
