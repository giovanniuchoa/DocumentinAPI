using DocumentinAPI.Data;
using DocumentinAPI.Domain.DTOs.Group;
using DocumentinAPI.Domain.DTOs.User;
using DocumentinAPI.Domain.Models;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using Mapster;
using Microsoft.EntityFrameworkCore;
using DocumentinAPI.Domain.DTOs.Auth;

namespace DocumentinAPI.Repository
{
    public class GroupRepository : BaseRepository, IGroupRepository
    {

        public GroupRepository(DBContext context) : base(context)
        {
        }

        public async Task<Retorno<GroupResponseDTO>> GetGroupByIdAsync(int groupId, UserClaimDTO ssn)
        {

            Retorno<GroupResponseDTO> oRetorno = new();
            
            try
            {

                var grupoDB = await _context.Groups
                    .Include(g => g.User)
                    .Where(g => g.GroupId == groupId
                        && g.User.CompanyId == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                if (grupoDB == null)
                {
                    throw new Exception("notFound");
                }

                var grupo = grupoDB.Adapt<GroupResponseDTO>();

                grupo.CompanyId = grupoDB.User.CompanyId;

                oRetorno.Objeto = grupo;
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<IEnumerable<GroupResponseDTO>>> GetListGroupAsync(UserClaimDTO ssn)
        {

            Retorno<IEnumerable<GroupResponseDTO>> oRetorno = new();

            try
            {

                var grupoListDB = await _context.Groups
                    .Include(g => g.User)
                    .Where(g => g.User.CompanyId == ssn.CompanyId)
                    .ToListAsync();

                var grupoList = grupoListDB.Adapt<List<GroupResponseDTO>>();

                foreach (var grupo in grupoList)
                {
                    grupo.CompanyId = grupoListDB.FirstOrDefault(g => g.GroupId == grupo.GroupId).User.CompanyId;
                }

                oRetorno.Objeto = grupoList;

                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<GroupResponseDTO>> AddGroupAsync(GroupRequestDTO group, UserClaimDTO ssn)
        {
            
            Retorno<GroupResponseDTO> oRetorno = new();

            try
            {

                var grupoDB = group.Adapt<Group>();

                grupoDB.UserId = ssn.UserId;
                grupoDB.IsActive = true;
                grupoDB.CreatedAt = DateTime.Now;
                grupoDB.UpdatedAt = DateTime.Now;

                await _context.Groups.AddAsync(grupoDB);

                await _context.SaveChangesAsync();

                oRetorno.Objeto = grupoDB.Adapt<GroupResponseDTO>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<GroupResponseDTO>> UpdateGroupAsync(GroupRequestDTO group, UserClaimDTO ssn)
        {
            
            Retorno<GroupResponseDTO> oRetorno = new();

            try
            {

                var grupoDB = await _context.Groups
                    .Include(g => g.User)
                    .Where(g => g.GroupId == group.GroupId
                        && g.IsActive == true
                        && g.User.CompanyId == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                if (grupoDB == null)
                {
                    throw new Exception("notFound");
                }

                grupoDB.Name = group.Name;
                grupoDB.Description = group.Description;

                await _context.SaveChangesAsync();

                var grupo = grupoDB.Adapt<GroupResponseDTO>();

                grupo.CompanyId = grupoDB.User.CompanyId;

                oRetorno.Objeto = grupo;
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<GroupResponseDTO>> ToggleStatusGroupAsync(int groupId, UserClaimDTO ssn)
        {
            
            Retorno<GroupResponseDTO> oRetorno = new();

            try
            {

                var grupoDB = await _context.Groups
                    .Include(g => g.User)
                    .Where(g => g.GroupId == groupId
                        && g.User.CompanyId == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                if (grupoDB == null)
                {
                    throw new Exception("notFound");
                }
                
                grupoDB.IsActive = !grupoDB.IsActive;
                grupoDB.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                var grupo = grupoDB.Adapt<GroupResponseDTO>();

                grupo.CompanyId = grupoDB.User.CompanyId;

                oRetorno.Objeto = grupo;
                oRetorno.SetSucesso();
            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<IEnumerable<UserResponseDTO>>> GetListUserXGroupByGroupAsync(int groupId, UserClaimDTO ssn)
        {
            
            Retorno<IEnumerable<UserResponseDTO>> oRetorno = new();

            try
            {

                var userListDB = await _context.UserXGroups
                    .Include(ug => ug.User)
                    .Where(ug => ug.GroupId == groupId
                        && ug.User.CompanyId == ssn.CompanyId
                        && (ssn.Profile == 1 || (ssn.Profile == 2 && ug.User.Profile != 1) || (ug.User.UserId == ssn.UserId)) )
                    .Select(ug => ug.User)
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
