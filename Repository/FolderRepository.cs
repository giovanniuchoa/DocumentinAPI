using DocumentinAPI.Data;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Folder;
using DocumentinAPI.Domain.DTOs.FolderXGroup;
using DocumentinAPI.Domain.DTOs.Group;
using DocumentinAPI.Domain.Models;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Supabase.Gotrue;

namespace DocumentinAPI.Repository
{
    public class FolderRepository : BaseRepository, IFolderRepository
    {

        public FolderRepository(DBContext context) : base(context)
        {
        }

        public async Task<Retorno<FolderResponseDTO>> GetFolderByIdAsync(int folderId, UserClaimDTO ssn)
        {

            Retorno<FolderResponseDTO> oRetorno = new Retorno<FolderResponseDTO>();

            try
            {

                var folderDB = await _context.Folders
                    .Include(f => f.User)
                    .Include(f => f.Documents.Where(d => d.IsValid == true))
                    .Where(f => f.FolderId == folderId
                        && f.User.CompanyId == ssn.CompanyId
                        && ssn.FoldersIdsList.Contains(f.FolderId))
                    .FirstOrDefaultAsync();

                if (folderDB == null)
                {
                    throw new Exception("folderNotFound");
                }

                oRetorno.Objeto = folderDB.Adapt<FolderResponseDTO>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<ICollection<FolderResponseDTO>>> GetListFolderAsync(UserClaimDTO ssn)
        {

            Retorno<ICollection<FolderResponseDTO>> oRetorno = new Retorno<ICollection<FolderResponseDTO>>();

            try
            {

                var folderListDB = await _context.Folders
                    .Include(t => t.User)
                    .Include(t => t.Documents.Where(d => d.IsValid == true))
                    .Where(t => t.User.CompanyId == ssn.CompanyId
                        && ssn.FoldersIdsList.Contains(t.FolderId))
                    .ToListAsync();

                oRetorno.Objeto = folderListDB.Adapt<List<FolderResponseDTO>>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;


        }

        public async Task<Retorno<FolderResponseDTO>> AddFolderAsync(FolderRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<FolderResponseDTO> oRetorno = new Retorno<FolderResponseDTO>();

            try
            {

                var folderDB = await _context.Folders
                    .Include(t => t.User)
                    .Where(t => t.User.CompanyId == ssn.CompanyId
                        && t.ParentFolderId == dto.ParentFolderId
                        && t.Name == dto.Name)
                    .FirstOrDefaultAsync();

                if (folderDB != null)
                {
                    throw new Exception("folderNameAlreadyExists");
                }

                if (dto.ParentFolderId != null)
                {

                    var parentFolderDB = await _context.Folders
                        .Include(t => t.User)
                        .Where(t => t.FolderId == dto.ParentFolderId
                            && t.User.CompanyId == ssn.CompanyId
                            && t.IsActive == true)
                        .FirstOrDefaultAsync();

                    if (parentFolderDB == null)
                    {
                        throw new Exception("parentFolderNotFound");
                    }

                }

                var validatorDB = await _context.Users
                    .Where(v => v.UserId == dto.ValidatorId
                        && v.CompanyId == ssn.CompanyId
                        && v.IsActive == true)
                    .FirstOrDefaultAsync();

                if (validatorDB == null)
                {

                    throw new Exception("validatorNotFound");

                }

                folderDB = dto.Adapt<Folder>();

                folderDB.UserId = ssn.UserId;
                folderDB.CreatedAt = DateTime.Now;
                folderDB.UpdatedAt = DateTime.Now;
                folderDB.IsActive = true;

                await _context.Folders.AddAsync(folderDB);

                await _context.SaveChangesAsync();

                oRetorno.Objeto = folderDB.Adapt<FolderResponseDTO>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;


        }

        public async Task<Retorno<FolderResponseDTO>> UpdateFolderAsync(FolderRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<FolderResponseDTO> oRetorno = new Retorno<FolderResponseDTO>();

            try
            {

                var folderDB = await _context.Folders
                    .Include(t => t.User)
                    .Where(t => t.FolderId == dto.FolderId
                        && t.User.CompanyId == ssn.CompanyId
                        && t.IsActive == true)
                    .FirstOrDefaultAsync();

                if (folderDB == null)
                {
                    throw new Exception("folderNotFound");
                }

                if (dto.ParentFolderId != null)
                {

                    var parentFolderDB = await _context.Folders
                        .Include(t => t.User)
                        .Where(t => t.FolderId == dto.ParentFolderId
                            && t.User.CompanyId == ssn.CompanyId
                            && t.IsActive == true)
                        .FirstOrDefaultAsync();

                    if (parentFolderDB == null)
                    {
                        throw new Exception("parentFolderNotFound");
                    }

                }

                var validatorDB = await _context.Users
                    .Where(v => v.UserId == dto.ValidatorId
                        && v.CompanyId == ssn.CompanyId
                        && v.IsActive == true)
                    .FirstOrDefaultAsync();

                if (validatorDB == null)
                {

                    throw new Exception("validatorNotFound");

                }

                folderDB.Name = dto.Name;
                folderDB.ParentFolderId = dto.ParentFolderId;
                folderDB.ValidatorId = dto.ValidatorId;
                folderDB.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                oRetorno.Objeto = folderDB.Adapt<FolderResponseDTO>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;


        }

        public async Task<Retorno<FolderResponseDTO>> ToogleStatusFolderAsync(int folderId, UserClaimDTO ssn)
        {

            Retorno<FolderResponseDTO> oRetorno = new Retorno<FolderResponseDTO>();

            try
            {

                var folderDB = await _context.Folders
                    .Include(t => t.User)
                    .Where(t => t.FolderId == folderId
                        && t.User.CompanyId == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                if (folderDB == null)
                {
                    throw new Exception("folderNotFound");
                }

                folderDB.IsActive = !folderDB.IsActive;
                folderDB.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                oRetorno.Objeto = folderDB.Adapt<FolderResponseDTO>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;


        }

        public async Task<Retorno<FolderResponseDTO>> MoveFolderAsync(MoveFolderRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<FolderResponseDTO> oRetorno = new Retorno<FolderResponseDTO>();

            try
            {

                var folderDB = await _context.Folders
                    .Include(f => f.User)
                    .Where(f => f.FolderId == dto.FolderId
                        && f.User.CompanyId == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                if (folderDB == null)
                {
                    throw new Exception("folderNotFound");
                }

                if (dto.ParentFolderId != null)
                {

                    var parentFolderDB = await _context.Folders
                        .Include(f => f.User)
                        .Where(f => f.FolderId == dto.ParentFolderId
                            && f.User.CompanyId == ssn.CompanyId)
                        .FirstOrDefaultAsync();

                    if (parentFolderDB == null)
                    {
                        throw new Exception("parentFolderNotFound");
                    }

                }

                folderDB.ParentFolderId = dto.ParentFolderId;
                folderDB.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                oRetorno.Objeto = folderDB.Adapt<FolderResponseDTO>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<IEnumerable<GroupResponseDTO>>> AddFolderXGroupAsync(FolderXGroupRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<IEnumerable<GroupResponseDTO>> oRetorno = new();

            try
            {

                var folderDB = await _context.Folders
                    .Include(f => f.User)
                    .Where(f => f.FolderId == dto.FolderId
                        && f.User.CompanyId == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                var grupoDB = await _context.Groups
                    .Include(g => g.User)
                    .Where(g => g.GroupId == dto.GroupId
                        && g.IsActive == true
                        && g.User.CompanyId == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                if (folderDB == null || grupoDB == null)
                {
                    throw new Exception("notFound");
                }

                var folderXGrupoDB = await _context.FolderXGroups
                    .Where(ug => ug.FolderId == dto.FolderId
                        && ug.GroupId == dto.GroupId)
                    .FirstOrDefaultAsync();

                if (folderXGrupoDB != null)
                {
                    throw new Exception("alreadyExists");
                }

                folderXGrupoDB = dto.Adapt<FolderXGroup>();

                folderXGrupoDB.CreatedAt = DateTime.Now;

                await _context.FolderXGroups.AddAsync(folderXGrupoDB);

                await _context.SaveChangesAsync();

                var listaGruposDB = await _context.FolderXGroups
                    .Include(ug => ug.Folder.User)
                    .Where(ug => ug.FolderId == dto.FolderId
                        && ug.Folder.User.CompanyId == ssn.CompanyId
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

        public async Task<Retorno<IEnumerable<GroupResponseDTO>>> DeleteFolderXGroupAsync(FolderXGroupRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<IEnumerable<GroupResponseDTO>> oRetorno = new();

            try
            {

                var folderDB = await _context.Folders
                    .Include(f => f.User)
                    .Where(f => f.FolderId == dto.FolderId
                        && f.User.CompanyId == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                var grupoDB = await _context.Groups
                    .Include(g => g.User)
                    .Where(g => g.GroupId == dto.GroupId
                        && g.IsActive == true
                        && g.User.CompanyId == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                if (folderDB == null || grupoDB == null)
                {
                    throw new Exception("notFound");
                }

                var folderXGrupoDB = await _context.FolderXGroups
                    .Where(ug => ug.FolderId == dto.FolderId
                        && ug.GroupId == dto.GroupId)
                    .FirstOrDefaultAsync();

                if (folderXGrupoDB == null)
                {
                    throw new Exception("notFound");
                }

                _context.FolderXGroups.Remove(folderXGrupoDB);

                await _context.SaveChangesAsync();

                var listaGruposDB = await _context.FolderXGroups
                    .Include(ug => ug.Folder.User)
                    .Where(ug => ug.FolderId == dto.FolderId
                        && ug.Folder.User.CompanyId == ssn.CompanyId
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

        public async Task<Retorno<IEnumerable<GroupResponseDTO>>> GetListFolderXGroupByFolderAsync(int folderId, UserClaimDTO ssn)
        {

            Retorno<IEnumerable<GroupResponseDTO>> oRetorno = new();

            try
            {

                var listaGruposDB = await _context.FolderXGroups
                    .Include(ug => ug.Folder.User)
                    .Where(ug => ug.FolderId == folderId
                        && ug.Folder.User.CompanyId == ssn.CompanyId
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
    }
}
