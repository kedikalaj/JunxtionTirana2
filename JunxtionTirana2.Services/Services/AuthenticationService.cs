using JunxtionTirana2.Model;
using JunxtionTirana2.Model.ApplicationUsers;
using JunxtionTirana2.Services.Interfaces;
using JunxtionTirana2.Services.Models.LoginViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;
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
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthenticationService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> RegisterUserAsync(RegisterUserViewModel model)
        {
            var user = new User
            {
                UserName = model.Username,
                Email = model.Email,
                AvatarId = model.AvatarId,
                Education = model.Education,
                Description = model.Description,
                Skills = model.Skills
            };

            return await _userManager.CreateAsync(user, model.Password);
        }

        public async Task<User> AuthenticateUserAsync(LoginUserViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return null;
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, false, false);

            return result.Succeeded ? user : null;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
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
