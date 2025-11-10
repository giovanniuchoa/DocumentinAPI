using DocumentinAPI.Authentication;
using DocumentinAPI.Cryptography;
using DocumentinAPI.Data;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DocumentinAPI.Repository
{
    public class AuthRepository : BaseRepository, IAuthRepository
    {

        public AuthRepository(DBContext context) : base(context)
        {
        }

        public async Task<Retorno<AuthResponseDTO>> AuthenticateAsync(AuthRequestDTO model)
        {
            Retorno<AuthResponseDTO> oRetorno = new Retorno<AuthResponseDTO>();

            try
            {

                var usuario = await _context.Users
                    .Include(u => u.Company)
                    .Where(u => u.Email == model.Login
                        && u.IsActive == true
                        && u.Company.IsActive)
                    .FirstOrDefaultAsync();

                if (usuario == null || usuario.Password != model.Password.GenerateHash())
                {
                    throw new Exception("invalidCredentials");
                }

                var userClaims = usuario.Adapt<UserSession>();

                var userGroups = await _context.UserXGroups
                    .Where(ug => ug.UserId == usuario.UserId)
                    .Select(ug => ug.Group.GroupId)
                    .ToListAsync();

                var userFolders = await _context.FolderXGroups
                    .Where(fg => userGroups.Contains(fg.GroupId))
                    .Select(fg => fg.FolderId)
                    .Distinct()
                    .ToListAsync();

                var foldersCreated = await _context.Folders
                    .Where(f => f.UserId == usuario.UserId
                        && f.IsActive)
                    .Select(f => f.FolderId)
                    .ToListAsync();

                var allFolders = userFolders.Union(foldersCreated).ToList();

                userClaims.GroupsIds = userGroups?.Any() == true ? string.Join(",", userGroups) : null;

                userClaims.FoldersIds = allFolders?.Any() == true ? string.Join(",", allFolders) : null;

                usuario.LastLoginAt = DateTime.Now;

                await _context.SaveChangesAsync();

                oRetorno.Objeto = new(await TokenService.GenerateTokenAsync(userClaims));

                oRetorno.SetSucesso();
            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }
    }
}
