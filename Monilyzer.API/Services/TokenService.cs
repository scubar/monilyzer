using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Monilyzer.Data;
using Monilyzer.Model;

namespace Monilyzer.API.Services
{
    public class TokenService
    {
        public TokenService(MonilyzerContext monilyzerContext, IConfiguration configuration)
        {
            MonilyzerContext = monilyzerContext;
            Configuration = configuration;
        }

        private MonilyzerContext MonilyzerContext { get; set; }

        private IConfiguration Configuration { get; set; }

        public string GetToken(UsernamePassword usernamePassword)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SymmetricSecurityKey"]));

            var user = new UserService(MonilyzerContext).GetUser(usernamePassword.Username, usernamePassword.Password);

            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("DisplayName",user.Displayname) 
            };

            foreach(var role in user.UserRoles){
                claims.Add(new Claim(ClaimTypes.Role, role?.RoleName) ); 
            }

            var token = new JwtSecurityToken(
                issuer: "monilyzer.api",
                audience: "monilyzer.api clients",
                claims: claims.ToArray(),
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(4),
                signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}