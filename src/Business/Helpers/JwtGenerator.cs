using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using DAL.Entities;

namespace Business.Helpers
{
    public static class JwtGenerator
    {
        /*public static string GenerateJwt(UserEntity user)
        {
            var claims = GetClaims(user);
        }

        public static string GenerateJwt(IEnumerable<Claim> claims)
        {

        }*/

        private static IEnumerable<Claim> GetClaims(UserEntity user)
        {
            var roles = user.UserRoles.Select(u => new Claim(ClaimTypes.Role, u.Role.Title));

            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new (ClaimTypes.Email, user.Email),
                new (ClaimTypes.Name, user.Name),
                new (ClaimTypes.Surname, user.Surname),
                new (ClaimTypes.MobilePhone, user.PhoneNumber)
            };
            claims.AddRange(claims);
            return claims;
        }
    }
}