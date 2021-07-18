using Microsoft.IdentityModel.Tokens;
using ServerApp.Model;
using ServerApp.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ServerApp
{
    class AuthManager : IAuthManager
    {
        private readonly string tokenKey;

        public AuthManager(string tokenKey)
        {
            this.tokenKey = tokenKey;
        }

        public string Authenticate(string email, string password, Patient patient)
        {

            if (!(patient.email==email&&patient.password==password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
