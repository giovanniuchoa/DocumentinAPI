using DocumentinAPI.Domain.Models;
using DocumentinAPI.Domain.Utils;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace DocumentinAPI.Authentication
{
    public static class TokenService
    {

        public static string GenerateToken(User usuario)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.UserId.ToString()),
                    new Claim(ClaimTypes.Name, usuario.Name),
                    new Claim(ClaimTypes.Role, usuario.Profile.ToString()),
                    new Claim("CompanyId", usuario.CompanyId.ToString())
                }),

                Expires = DateTime.UtcNow.AddHours(8),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }

        /* Possibilita chamada do método assíncrono */
        public static Task<string> GenerateTokenAsync(User usuario)
        {
            return System.Threading.Tasks.Task.FromResult(GenerateToken(usuario));
        }

        public static string GetValueFromClaim(IIdentity identity, string field)
        {
            var claims = identity as ClaimsIdentity;

            return claims.FindFirst(field).Value;
        }

        public static UserSession GetClaimsData(ClaimsPrincipal user)
        {
            return new UserSession
            {
                UserId = int.Parse(user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value),
                Name = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value,
                Profile = int.Parse(user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value),
                CompanyId = int.Parse(user.Claims.FirstOrDefault(c => c.Type == "CompanyId")?.Value)

            };
        }

    }
}
