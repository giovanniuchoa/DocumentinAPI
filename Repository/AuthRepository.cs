using DocumentinAPI.Authentication;
using DocumentinAPI.Data;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
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

                /* TODO por enquanto esta simples só para teste */

                var usuario = await _context.Users
                    .Where(u => u.Email == model.Login 
                        && u.Password == model.Password
                        && u.IsActive == true)
                    .FirstOrDefaultAsync();

                if (usuario == null)
                {
                    throw new Exception("Usuário ou senha inválidos");
                }

                oRetorno.Objeto = new(await TokenService.GenerateTokenAsync(usuario));

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
