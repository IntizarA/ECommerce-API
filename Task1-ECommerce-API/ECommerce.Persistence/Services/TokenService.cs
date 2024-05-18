using ECommerce.Application.Services;
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

namespace ECommerce.Persistence.Services
{
    public class TokenService : ITokenService
    {
        private SymmetricSecurityKey _securityKey;

        public TokenService(IConfiguration configuration)
        {
            byte[] keyBytes = GenerateRandomKeyBytes(64);
            _securityKey = new SymmetricSecurityKey(keyBytes);
        }

        private byte[] GenerateRandomKeyBytes(int size)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] keyBytes = new byte[size];
                rng.GetBytes(keyBytes);
                return keyBytes;
            }
        }

        public string CreateToken(string value)
        {
            List<Claim> claims = new()
            {
                new Claim(JwtRegisteredClaimNames.Email, value)
            };

            var credentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = credentials
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);


            return tokenHandler.WriteToken(token);
        }
    }
}
