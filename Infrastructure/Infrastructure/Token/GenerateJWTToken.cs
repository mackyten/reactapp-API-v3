﻿using Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Token
{
    public class GenerateJWTToken : IGenerateJWTToken
    {

        private readonly IConfiguration _configuration;

        public GenerateJWTToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Generate(User user) 
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("gTqVff3L2j93ufiWf4l0"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(ClaimTypes.Email, user.Email)
            };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
