using JunxtionTirana2.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JunxtionTirana2.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationService()
        {

        }

        public JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hjdfytf6vi56ygf4w3sasj"));
            var token = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                expires: DateTime.Now.AddHours(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)

                );
            return token;
        }
    }
}
