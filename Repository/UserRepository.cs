using DocumentinAPI.Data;
using DocumentinAPI.Domain.DTOs.User;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DocumentinAPI.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {

        public UserRepository(DBContext context) : base(context)
        {
        }

        public async Task<Retorno<UserResponseDTO>> GetUserByIdAsync(int userId, UserSession ssn)
        {
           
            Retorno<UserResponseDTO> oRetorno = new Retorno<UserResponseDTO>();

            try
            {

                var userDB = await _context.Users
                    .Where(u => u.UserId == userId
                        && u.IsActive == true
                        && u.CompanyId.ToString() == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                if (userDB == null)
                {
                    throw new Exception("notFound");
                }

                oRetorno.Objeto = userDB.Adapt<UserResponseDTO>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);  
            }

            return oRetorno;

        }

        public async Task<Retorno<IEnumerable<UserResponseDTO>>> GetListUserAsync(UserSession ssn)
        {
            Retorno<IEnumerable<UserResponseDTO>> oRetorno = new();

            try
            {

                var userListDB = await _context.Users
                    .Where(u => u.IsActive == true
                        && u.CompanyId.ToString() == ssn.CompanyId)
                    .ToListAsync();

                oRetorno.Objeto = userListDB.Adapt<List<UserResponseDTO>>();

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
