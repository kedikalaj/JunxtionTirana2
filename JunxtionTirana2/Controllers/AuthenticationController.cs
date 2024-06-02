using JunxtionTirana2.JunxtionTirana2.Models;
using JunxtionTirana2.Model.ApplicationUsers;
using JunxtionTirana2.Services.Interfaces;
using JunxtionTirana2.Services.Models.LoginViewModel;
using JunxtionTirana2.ViewModels.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace JunxtionTirana2.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<User> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(UserManager<User> userManager, RoleManager<User> roleManager, IConfiguration configuration, IAuthenticationService authenticationService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _authenticationService = authenticationService;
        }

        //[HttpPost("Register")]
        //public async Task<IActionResult> Register([FromBody] RegisterUserViewModel model, string role)
        //{
        //    var userExists = await _userManager.FindByEmailAsync(model.Email);
        //    if (userExists != null)
        //    {
        //        return Unauthorized("The user already exists!");
        //    }
        //    IdentityUser user = new IdentityUser()
        //    {
        //        Email = model.Email,
        //        PhoneNumber = model.Phone,
        //        SecurityStamp = Guid.NewGuid().ToString(),
        //        UserName = model.Username
        //    };

        //    var result = await _userManager.CreateAsync(user, model.Password);
        //    if (!result.Succeeded)
        //    {
        //        return BadRequest("Could not create user.");
        //    }

        //    if (await _roleManager.RoleExistsAsync(role))
        //    {
        //        var addroles = await _userManager.AddToRoleAsync(user, role);
        //        return Ok();
        //    }
        //    else
        //    {
        //        return BadRequest("The role doesnt exists.");
        //    }
        //}

        //[HttpPost("Login")]
        //public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        //{
        //    var user = await _userManager.FindByNameAsync(model.Username);

        //    if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        //    {
        //        var authClaims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, user.UserName),
        //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //        };
        //        var jwtToken = _authenticationService.GetToken(authClaims);
        //        return Ok(new
        //        {
        //            token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
        //            expiration = jwtToken.ValidTo,
        //            user = user
        //        });
        //    }
        //    return Unauthorized();
        //}
        [HttpPost("register")]
        public async Task<IActionResult> Register(Services.Models.LoginViewModel.RegisterUserViewModel model)
        {
            var existingUser = await _authenticationService.GetUserByEmailAsync(model.Email);
            if (existingUser != null)
            {
                return BadRequest("User with this email already exists.");
            }

            var result = await _authenticationService.RegisterUserAsync(model);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserViewModel model)
        {
            var user = await _authenticationService.AuthenticateUserAsync(model);
            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            // Here, you would typically generate a JWT token and return it to the user
            // For simplicity, we'll just return the user object
            return Ok(user);
        }

    }
}