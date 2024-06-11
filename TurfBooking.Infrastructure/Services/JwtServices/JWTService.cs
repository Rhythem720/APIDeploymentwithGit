using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TurfBooking.Domain.Entities;

namespace TurfBooking.Infrastructure.JwtServices
{
    public class JWTService
    {
        private readonly IConfiguration _configuration;

        public JWTService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
        public string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //var issuer = _configuration["Jwt:Issuer"];
            //var audience = _configuration["Jwt:Audience"];
            //var duration = _configuration["Jwt:Duration"];

            var claims = new[] {
        new Claim(ClaimTypes.Name, userInfo.UserName),
        new Claim("Email", userInfo.UserEmail),
        new Claim("Address",userInfo.Address),
        new Claim("PhoneNo",userInfo.PhoneNo),
        new Claim("Gender",userInfo.Gender),
        //new Claim("Role",userInfo.Role),
        new Claim(ClaimTypes.Role,userInfo.Role)
        
    };

            var token = new JwtSecurityToken(
                issuer:_configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                //issuer:issuer,
                //audience:audience,
               claims: claims,
                expires: DateTime.Now.AddMinutes(Int32.Parse(_configuration["Jwt:Duration"])),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
