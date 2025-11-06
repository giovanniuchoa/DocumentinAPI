using DocumentinAPI.Cryptography;
using DocumentinAPI.Data;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Email;
using DocumentinAPI.Domain.DTOs.Group;
using DocumentinAPI.Domain.DTOs.PasswordRecovery;
using DocumentinAPI.Domain.DTOs.User;
using DocumentinAPI.Domain.DTOs.UserXGroup;
using DocumentinAPI.Domain.Models;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static DocumentinAPI.Domain.Utils.Helpers;
using static DocumentinAPI.Domain.Utils.TemplateHelpers;

namespace DocumentinAPI.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {

        private readonly IEmailService _emailService;

        public UserRepository(DBContext context, IEmailService emailService) : base(context)
        {
            _emailService = emailService;
        }

        public async Task<Retorno<UserResponseDTO>> GetUserByIdAsync(int userId, UserClaimDTO ssn)
        {
           
            Retorno<UserResponseDTO> oRetorno = new Retorno<UserResponseDTO>();

            try
            {

                var userDB = await _context.Users
                    .Where(u => u.UserId == userId
                        && u.IsActive == true
                        && (ssn.Profile == 1 || (ssn.Profile == 2 && u.Profile != 1) || (u.UserId == ssn.UserId)) )
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

        public async Task<Retorno<IEnumerable<UserResponseDTO>>> GetListUserAsync(UserClaimDTO ssn)
        {
            Retorno<IEnumerable<UserResponseDTO>> oRetorno = new();

            try
            {

                var userListDB = await _context.Users
                    .Where(u => ssn.Profile == 1 || (ssn.Profile == 2 && u.Profile != 1) && u.CompanyId == ssn.CompanyId || (u.UserId == ssn.UserId) )
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

        public async Task<Retorno<UserResponseDTO>> AddUserAsync(UserRequestDTO dto, UserClaimDTO ssn)
        {
            
            Retorno<UserResponseDTO> oRetorno = new();

            try
            {

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
                userDB.CompanyId = dto.CompanyId;
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

        public async Task<Retorno<UserResponseDTO>> UpdateUserAsync(UserRequestDTO dto, UserClaimDTO ssn)
        {
            
            Retorno<UserResponseDTO> oRetorno = new();

            try
            {

                var userDB = await _context.Users
                    .Where(u => u.UserId == dto.UserId
                        && u.IsActive == true
                        && (ssn.Profile == (int)Enums.TipoUsuario.AdministradorDev || u.CompanyId == ssn.CompanyId))
                    .FirstOrDefaultAsync();

                if (userDB == null)
                {
                    throw new Exception("notFound");
                }

                if (ssn.Profile == 2 && userDB.Profile == 1)
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

        public async Task<Retorno<UserResponseDTO>> ToggleStatusUserAsync(int userId, UserClaimDTO ssn)
        {
            
            Retorno<UserResponseDTO> oRetorno = new();

            try
            {

                var userDB = await _context.Users
                    .Where(u => u.UserId == userId
                        && (ssn.Profile == (int)Enums.TipoUsuario.AdministradorDev || u.CompanyId == ssn.CompanyId))
                    .FirstOrDefaultAsync();

                if (ssn.Profile == 2 && userDB.Profile == 1)
                {
                    throw new Exception("noPermission");
                }

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

        public async Task<Retorno<IEnumerable<GroupResponseDTO>>> GetListUserXGroupByUserAsync(int userId, UserClaimDTO ssn)
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

        public async Task<Retorno<IEnumerable<GroupResponseDTO>>> AddUserXGroupAsync(UserXGroupRequestDTO model, UserClaimDTO ssn)
        {

            Retorno<IEnumerable<GroupResponseDTO>> oRetorno = new();

            try
            {

                var userDB = await _context.Users
                    .Where(u => u.UserId == model.UserId
                        && u.CompanyId == ssn.CompanyId
                        && (ssn.Profile == 1 || (ssn.Profile == 2 && u.Profile != 1) || (u.UserId == ssn.UserId)) )
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

                userXGrupoDB.CreatedAt = DateTime.Now;  

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

        public async Task<Retorno<IEnumerable<GroupResponseDTO>>> DeleteUserXGroupAsync(UserXGroupRequestDTO model, UserClaimDTO ssn)
        {

            Retorno<IEnumerable<GroupResponseDTO>> oRetorno = new();

            try
            {

                var userDB = await _context.Users
                    .Where(u => u.UserId == model.UserId
                        && u.CompanyId == ssn.CompanyId
                        && (ssn.Profile == 1 || (ssn.Profile == 2 && u.Profile != 1) || (u.UserId == ssn.UserId)) )
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

                var recoveryListDB = await _context.PasswordRecoveries
                    .Where(p => p.UserId == userDB.UserId
                        && p.IsActive == true)
                    .ToListAsync();

                if (recoveryListDB != null && recoveryListDB.Count > 0)
                {

                    foreach (var recoveryDB in recoveryListDB)
                    {
                        recoveryDB.IsActive = false;
                    }                    

                    await _context.SaveChangesAsync();
                }

                PasswordRecovery passwordRecoveryDB = new PasswordRecovery
                {
                    UserId = userDB.UserId,
                    Token = GerarTokenNumerico(6),
                    CreatedAt = DateTime.Now,
                    IsActive = true,
                    IsValidated = false
                };

                await _context.PasswordRecoveries.AddAsync(passwordRecoveryDB);

                await _context.SaveChangesAsync();

                var dados = new PasswordRecoveryEmailTemplateDTO
                {
                    Name = userDB.Name,
                    Token = passwordRecoveryDB.Token
                };

                _emailService.SendEmailPasswordRecovery(userDB.Email, dados);

                oRetorno.Objeto = passwordRecoveryDB.Adapt<PasswordRecoveryResponseDTO>();

                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<ValidatePasswordRecoveryResponseDTO>> ValidateTokenPasswordRecoveryAsync(ValidatePasswordRecoveryRequestDTO model)
        {
            
            Retorno<ValidatePasswordRecoveryResponseDTO> oRetorno = new();

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

                var recoveryDB = await _context.PasswordRecoveries
                    .Where(p => p.UserId == userDB.UserId
                        && p.IsActive == true)
                    .FirstOrDefaultAsync();

                if (recoveryDB == null) 
                {
                    throw new Exception("notFoundRecovery");
                }
                
                if (recoveryDB.Token == model?.Token)
                {

                    recoveryDB.IsValidated = true;

                    await _context.SaveChangesAsync();

                }
                else
                {
                    throw new Exception("invalidToken");
                }

                oRetorno.Objeto = recoveryDB.Adapt<ValidatePasswordRecoveryResponseDTO>();

                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<UserResponseDTO>> UpdatePasswordRecoveryAsync(UpdatePasswordRecoveryRequestDTO model)
        {
            
            Retorno<UserResponseDTO> oRetorno = new();

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

                var recoveryDB = await _context.PasswordRecoveries
                    .Where(p => p.UserId == userDB.UserId
                        && p.IsActive == true)
                    .FirstOrDefaultAsync();

                if (recoveryDB == null)
                {
                    throw new Exception("notFoundRecovery");
                }

                if (recoveryDB.Token != model?.Token || recoveryDB.IsValidated == false)
                {
                    throw new Exception("notValidatedRecovery");
                }

                if (model.NewPassword == null)
                {
                    throw new Exception("invalidCredentials");
                }

                userDB.Password = model.NewPassword.GenerateHash();

                recoveryDB.IsActive = false;

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
