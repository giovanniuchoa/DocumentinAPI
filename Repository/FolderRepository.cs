using DocumentinAPI.Data;
using DocumentinAPI.Domain.DTOs.Folder;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DocumentinAPI.Repository
{
    public class FolderRepository : BaseRepository, IFolderRepository
    {

        public FolderRepository(DBContext context) : base(context)
        {
        }

        public async Task<Retorno<FolderResponseDTO>> GetFolderByIdAsync(int folderId, UserSession ssn)
        {

            Retorno<FolderResponseDTO> oRetorno = new Retorno<FolderResponseDTO>();

            try
            {

                var folderDB = await _context.Folders
                    .Include(f => f.User)
                    .Where(f => f.FolderId == folderId
                        && f.User.CompanyId == ssn.CompanyId)
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

        public async Task<Retorno<ICollection<FolderResponseDTO>>> GetListFolderAsync(UserSession ssn)
        {

            Retorno<ICollection<FolderResponseDTO>> oRetorno = new Retorno<ICollection<FolderResponseDTO>>();

            try
            {

                var folderListDB = await _context.Folders
                    .Include(t => t.User)
                    .Where(t => t.User.CompanyId == ssn.CompanyId)
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

        public async Task<Retorno<FolderResponseDTO>> AddFolderAsync(FolderRequestDTO dto, UserSession ssn)
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

                folderDB = dto.Adapt<Domain.Models.Folder>();

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

        public async Task<Retorno<FolderResponseDTO>> UpdateFolderAsync(FolderRequestDTO dto, UserSession ssn)
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

                folderDB.Name = dto.Name;
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

        public async Task<Retorno<FolderResponseDTO>> ToogleStatusFolderAsync(int folderId, UserSession ssn)
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

    }
}
