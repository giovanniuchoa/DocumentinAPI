using DocumentinAPI.Data;
using DocumentinAPI.Domain.DTOs.User;
using DocumentinAPI.Domain.Models;
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
                        && u.CompanyId == ssn.CompanyId)
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
                    .Where(u => u.CompanyId == ssn.CompanyId)
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

        public async Task<Retorno<UserResponseDTO>> AddUserAsync(UserRequestDTO dto, UserSession ssn)
        {
            
            Retorno<UserResponseDTO> oRetorno = new();

            try
            {

                if (!("1,2").Contains(ssn.Profile.ToString()))
                {
                    throw new Exception("noPermission");
                }

                var userDB = dto.Adapt<User>();

                userDB.CompanyId = ssn.CompanyId;
                userDB.CreatedAt = DateTime.Now;
                userDB.UpdatedAt = DateTime.Now;
                userDB.IsActive = true;

                await _context.Users.AddAsync(userDB);

                await _context.SaveChangesAsync();

                oRetorno.Objeto = userDB.Adapt<UserResponseDTO>();

                oRetorno.SetSucesso();  

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<UserResponseDTO>> UpdateUserAsync(UserRequestDTO dto, UserSession ssn)
        {
            
            Retorno<UserResponseDTO> oRetorno = new();

            try
            {

                var userDB = await _context.Users
                    .Where(u => u.UserId == dto.UserId
                        && u.IsActive == true
                        && u.CompanyId == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                if (userDB == null)
                {
                    throw new Exception("notFound");
                }

                if (!("1,2").Contains(ssn.Profile.ToString()) && userDB.UserId != ssn.UserId)
                {
                    throw new Exception("noPermission");
                }

                userDB.Name = dto.Name;
                userDB.Email = dto.Email;
                userDB.Password = dto.Password;
                userDB.Profile = dto.Profile;
                userDB.PreferredLanguage = dto.PreferredLanguage;
                userDB.PreferredTheme = dto.PreferredTheme;
                userDB.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                oRetorno.Objeto = userDB.Adapt<UserResponseDTO>();

                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<UserResponseDTO>> ToggleStatusUserAsync(int userId, UserSession ssn)
        {
            
            Retorno<UserResponseDTO> oRetorno = new();

            try
            {

                if (!("1,2").Contains(ssn.Profile.ToString()))
                {
                    throw new Exception("noPermission");
                }

                var userDB = await _context.Users
                    .Where(u => u.UserId == userId
                        && u.CompanyId == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                if (userDB == null)
                {
                    throw new Exception("notFound");
                }

                userDB.IsActive = !userDB.IsActive;
                userDB.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                oRetorno.Objeto = userDB.Adapt<UserResponseDTO>();

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
