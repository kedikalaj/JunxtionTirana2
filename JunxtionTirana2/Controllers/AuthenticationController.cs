﻿using JunxtionTirana2.JunxtionTirana2.Models;
using JunxtionTirana2.Services.Interfaces;
using JunxtionTirana2.ViewModels.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace JunxtionTirana2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IEmailService emailService, IAuthenticationService authenticationService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _emailService = emailService;
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserViewModel model, string role)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
            {
                return Unauthorized("The user already exists!");
            }
            IdentityUser user = new IdentityUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest("Could not create user.");
            }

            if (await _roleManager.RoleExistsAsync(role))
            {
                var addroles = await _userManager.AddToRoleAsync(user, role);
                return Ok();
            }
            else
            {
                return BadRequest("The role doesnt exists.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                var jwtToken = _authenticationService.GetToken(authClaims);
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    expiration = jwtToken.ValidTo,
                    user = user
                });
            }
            return Unauthorized();
        }
        [HttpPost]
        public IActionResult TestEmail()
        {
            try
            {
                string content = "<p>The content</p>";
                var msg = new Message(new string[] { "testemai@email.test" }, "Email test", content);
                _emailService.SendEmail(msg);
                return Ok("Message sent successfully");
            }
            catch
            {
                return BadRequest("Something went wrong!");
            }
        }
    }
}