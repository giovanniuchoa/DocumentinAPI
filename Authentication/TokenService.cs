using DocumentinAPI.Domain.DTOs.Auth;
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

        public static string GenerateToken(UserSession usuario)
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
                    new Claim("CompanyId", usuario.CompanyId.ToString()),
                    new Claim("GroupsIds", usuario.GroupsIds != null ? usuario.GroupsIds : ""),
                    new Claim("FoldersIds", usuario.FoldersIds != null ? usuario.FoldersIds : "")
                }),

                Expires = DateTime.UtcNow.AddHours(8),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }

        /* Possibilita chamada do método assíncrono */
        public static Task<string> GenerateTokenAsync(UserSession usuario)
        {
            return System.Threading.Tasks.Task.FromResult(GenerateToken(usuario));
        }

        public static string GetValueFromClaim(IIdentity identity, string field)
        {
            var claims = identity as ClaimsIdentity;

            return claims.FindFirst(field).Value;
        }

        private static List<int> ConvertStringToIntList(string commaSeparatedIds)
        {
            if (string.IsNullOrEmpty(commaSeparatedIds))
                return new List<int>();

            return commaSeparatedIds.Split(',')
                                   .Select(id => int.Parse(id.Trim()))
                                   .ToList();
        }

        public static UserClaimDTO GetClaimsData(ClaimsPrincipal user)
        {
            return new UserClaimDTO
            {
                UserId = int.Parse(user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value),
                Name = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value,
                Profile = int.Parse(user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value),
                CompanyId = int.Parse(user.Claims.FirstOrDefault(c => c.Type == "CompanyId")?.Value),
                GroupsIdsList = ConvertStringToIntList(user.Claims.FirstOrDefault(c => c.Type == "GroupsIds")?.Value),
                FoldersIdsList = ConvertStringToIntList(user.Claims.FirstOrDefault(c => c.Type == "FoldersIds")?.Value)

            };
        }

    }
}
