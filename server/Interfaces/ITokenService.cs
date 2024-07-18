using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace server.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
        ClaimsPrincipal DecodeToken(string token);
    }
}