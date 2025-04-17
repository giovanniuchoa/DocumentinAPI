using DocumentinAPI.Cryptography;
using DocumentinAPI.Data;
using DocumentinAPI.Domain.DTOs.Group;
using DocumentinAPI.Domain.DTOs.PasswordRecovery;
using DocumentinAPI.Domain.DTOs.User;
using DocumentinAPI.Domain.DTOs.UserXGroup;
using DocumentinAPI.Domain.Models;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using Mapster;
using Microsoft.EntityFrameworkCore;
using static DocumentinAPI.Domain.Utils.Helpers;

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

                var userDTO = userDB.Adapt<UserResponseDTO>();

                oRetorno.Objeto = userDTO;
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

                var userDB = await _context.Users
                    .Where(u => u.Email == dto.Email
                        && u.IsActive == true)
                    .FirstOrDefaultAsync();

                if (userDB != null)
                {
                    throw new Exception("alreadyExistsEmail");
                }

                userDB = dto.Adapt<User>();

                userDB.Password = userDB.Password.GenerateHash();
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
                userDB.Password = dto.Password.GenerateHash();
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

        public async Task<Retorno<IEnumerable<GroupResponseDTO>>> GetListUserXGroupByUserAsync(int userId, UserSession ssn)
        {
            
            Retorno<IEnumerable<GroupResponseDTO>> oRetorno = new();

            try
            {

                var listaGruposDB = await _context.UserXGroups
                    .Include(ug => ug.User)
                    .Where(ug => ug.UserId == userId 
                        && ug.User.CompanyId == ssn.CompanyId 
                        && ug.Group.IsActive == true 
                        && ug.Group.User.CompanyId == ssn.CompanyId) 
                    .Select(ug => ug.Group)
                    .ToListAsync();

                oRetorno.Objeto = listaGruposDB.Adapt<List<GroupResponseDTO>>();

                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<IEnumerable<GroupResponseDTO>>> AddUserXGroupAsync(UserXGroupRequestDTO model, UserSession ssn)
        {

            Retorno<IEnumerable<GroupResponseDTO>> oRetorno = new();

            try
            {

                if (!("1,2").Contains(ssn.Profile.ToString()))
                {
                    throw new Exception("noPermission");
                }

                var userDB = await _context.Users
                    .Where(u => u.UserId == model.UserId
                        && u.CompanyId == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                var grupoDB = await _context.Groups
                    .Include(g => g.User)
                    .Where(g => g.GroupId == model.GroupId
                        && g.IsActive == true
                        && g.User.CompanyId == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                if (userDB == null || grupoDB == null )
                {
                    throw new Exception("notFound");
                }

                var userXGrupoDB = await _context.UserXGroups
                    .Where(ug => ug.UserId == model.UserId
                        && ug.GroupId == model.GroupId)
                    .FirstOrDefaultAsync();

                if (userXGrupoDB != null)
                {
                    throw new Exception("alreadyExists");
                }

                userXGrupoDB = model.Adapt<UserXGroup>();

                await _context.UserXGroups.AddAsync(userXGrupoDB);

                await _context.SaveChangesAsync();

                var listaGruposDB = await _context.UserXGroups
                    .Include(ug => ug.User)
                    .Where(ug => ug.UserId == model.UserId
                        && ug.User.CompanyId == ssn.CompanyId
                        && ug.Group.IsActive == true
                        && ug.Group.User.CompanyId == ssn.CompanyId)
                    .Select(ug => ug.Group)
                    .ToListAsync();

                oRetorno.Objeto = listaGruposDB.Adapt<List<GroupResponseDTO>>();

                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<IEnumerable<GroupResponseDTO>>> DeleteUserXGroupAsync(UserXGroupRequestDTO model, UserSession ssn)
        {

            Retorno<IEnumerable<GroupResponseDTO>> oRetorno = new();

            try
            {

                if (!("1,2").Contains(ssn.Profile.ToString()))
                {
                    throw new Exception("noPermission");
                }

                var userDB = await _context.Users
                    .Where(u => u.UserId == model.UserId
                        && u.CompanyId == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                var grupoDB = await _context.Groups
                    .Include(g => g.User)
                    .Where(g => g.GroupId == model.GroupId
                        && g.IsActive == true
                        && g.User.CompanyId == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                if (userDB == null || grupoDB == null)
                {
                    throw new Exception("notFound");
                }

                var userXGrupoDB = await _context.UserXGroups
                    .Where(ug => ug.UserId == model.UserId
                        && ug.GroupId == model.GroupId)
                    .FirstOrDefaultAsync();

                if (userXGrupoDB == null)
                {
                    throw new Exception("notFound");
                }

                _context.UserXGroups.Remove(userXGrupoDB);

                await _context.SaveChangesAsync();

                var listaGruposDB = await _context.UserXGroups
                    .Include(ug => ug.User)
                    .Where(ug => ug.UserId == model.UserId
                        && ug.User.CompanyId == ssn.CompanyId
                        && ug.Group.IsActive == true
                        && ug.Group.User.CompanyId == ssn.CompanyId)
                    .Select(ug => ug.Group)
                    .ToListAsync();

                oRetorno.Objeto = listaGruposDB.Adapt<List<GroupResponseDTO>>();

                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<PasswordRecoveryResponseDTO>> RequestPasswordRecoveryAsync(PasswordRecoveryRequestDTO model)
        {
            
            Retorno<PasswordRecoveryResponseDTO> oRetorno = new();

            try
            {

                var userDB = await _context.Users
                    .Where(u => u.Email == model.Email
                        && u.IsActive == true)
                    .FirstOrDefaultAsync();

                if (userDB == null)
                {
                    throw new Exception("notFound");
                }

                PasswordRecovery passwordRecoveryDB = new PasswordRecovery
                {
                    UserId = userDB.UserId,
                    Token = GerarTokenNumerico(6),
                    CreatedAt = DateTime.Now,
                    IsActive = true
                };

                await _context.PasswordRecoveries.AddAsync(passwordRecoveryDB);

                await _context.SaveChangesAsync();

                oRetorno.Objeto = passwordRecoveryDB.Adapt<PasswordRecoveryResponseDTO>();

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
