﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Store.Core.Entity.Identity;
using Store.Core.Servise.Contract;

namespace Store.Service.Token
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> CreateTokenAsync(AppUser user, UserManager<AppUser> userManager)
        {
            var AuthClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.GivenName,user.DisplayName),
                new Claim(ClaimTypes.Email,user.Email),

            };

            var UserRoles = await userManager.GetRolesAsync(user);
            foreach (var Role in UserRoles) 
            {
                AuthClaims.Add(new Claim(ClaimTypes.Role, Role));
            }

            var AuthKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var Token = new JwtSecurityToken
                (
                issuer: _configuration["JWT:ValidIssuser"],
                audience: _configuration["JWT:ValidAudience"],
                expires:DateTime.Now.AddDays(double.Parse(_configuration["JWT:DurationInDays"])),
                claims:AuthClaims,
                signingCredentials:new SigningCredentials(AuthKey,SecurityAlgorithms.HmacSha256Signature)

                );

            return new JwtSecurityTokenHandler().WriteToken(Token);
        }
    }
}
