using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Monilyzer.Data;

namespace Monilyzer.API.Services
{
    public class TokenService
    {
        public TokenService(MonilyzerContext monilyzerContext)
        {
            MonilyzerContext = monilyzerContext;
        }

        private MonilyzerContext MonilyzerContext { get; set; }

        public string GetToken(string username, string password)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DEVDEVDEVDEVDEVDEV"));

            //TODO: Validate Username/Password
            //TODO: Get Claims from User Object


            var claims = new Claim[] {
                new Claim(ClaimTypes.Name, "User"),
                new Claim(ClaimTypes.Role, "Administrator"), 
                new Claim(JwtRegisteredClaimNames.Email, "user@site.com")
            };

            var token = new JwtSecurityToken(
                issuer: "monilyzer.api",
                audience: "monilyzer.api clients",
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(4),
                signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}