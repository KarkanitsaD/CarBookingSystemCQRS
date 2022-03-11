using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Business.Options;
using DAL.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Business.Helpers
{
    public class TokenHelper
    {
        private readonly IOptions<JwtOptions> _jwtOptions;

        public TokenHelper(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }

        public string GenerateJwt(UserEntity user)
        {
            var claims = GetClaims(user);
            return GenerateJwt(claims);
        }

        public string GenerateJwt(IEnumerable<Claim> claims)
        {
            var credentials = new SigningCredentials(_jwtOptions.Value.SymmetricSecurityKey,
                SecurityAlgorithms.HmacSha256Signature);

            var jwt = new JwtSecurityToken
            (
                issuer: _jwtOptions.Value.Issuer,
                audience: _jwtOptions.Value.Audience,
                claims: claims,
                expires: DateTime.Now.AddSeconds(_jwtOptions.Value.TokenLifeTimeInSeconds),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private IEnumerable<Claim> GetClaims(UserEntity user)
        {
            var roles = user.UserRoles.Select(u => new Claim(ClaimTypes.Role, u.Role.Title)).ToList();

            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new (ClaimTypes.Email, user.Email),
                new (ClaimTypes.Name, user.Name),
                new (ClaimTypes.Surname, user.Surname),
            };
            claims.AddRange(roles);
            return claims;
        }
    }
}