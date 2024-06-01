using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JunxtionTirana2.Services.Interfaces
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Generates the authentication tokens
        /// </summary>
        /// <param name="authClaims"></param>
        /// <returns></returns>
        JwtSecurityToken GetToken(List<Claim> authClaims);
    }
}
