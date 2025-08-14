using DocumentinAPI.Data;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.DTOs.Tag;
using DocumentinAPI.Domain.Models;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DocumentinAPI.Repository
{
    public class TagRepository : BaseRepository, ITagRepository
    {
        public TagRepository(DBContext context) : base(context)
        {
        }

        public async Task<Retorno<DocumentXTagResponseDTO>> AddDocumentXTagAsync(int documentId, int tagId, UserClaimDTO ssn)
        {
            throw new NotImplementedException();
        }

        public async Task<Retorno<TagResponseDTO>> AddTagAsync(TagRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<TagResponseDTO> oRetorno = new();

            try
            {

                var tagDB = dto.Adapt<Tag>();

                tagDB.CreatedAt = DateTime.Now;
                tagDB.UpdatedAt = DateTime.Now;
                tagDB.UserId = ssn.UserId;

                await _context.Tags.AddAsync(tagDB);

                await _context.SaveChangesAsync();

                oRetorno.Objeto = tagDB.Adapt<TagResponseDTO>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<DocumentXTagResponseDTO>> DeleteDocumentXTagAsync(int documentId, int tagId, UserClaimDTO ssn)
        {
            throw new NotImplementedException();
        }

        public async Task<Retorno<IEnumerable<TagResponseDTO>>> GetDocumentXTagByDocumentIdAsync(int documentId, UserClaimDTO ssn)
        {
            throw new NotImplementedException();
        }

        public async Task<Retorno<IEnumerable<DocumentResponseDTO>>> GetDocumentXTagByTagIdAsync(int tagId, UserClaimDTO ssn)
        {
            throw new NotImplementedException();
        }

        public async Task<Retorno<IEnumerable<TagResponseDTO>>> GetListTagAsync(UserClaimDTO ssn)
        {

            Retorno<IEnumerable<TagResponseDTO>> oRetorno = new();

            try
            {

                var tagDB = await _context.Tags
                    .Include(t => t.User)
                    .Where(t => t.User.CompanyId == ssn.CompanyId)
                    .ToListAsync();

                if (tagDB == null)
                {
                    throw new Exception("tagNotFound");
                }

                oRetorno.Objeto = tagDB.Adapt<List<TagResponseDTO>>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<TagResponseDTO>> GetTagByIdAsync(int tagId, UserClaimDTO ssn)
        {

            Retorno<TagResponseDTO> oRetorno = new();

            try
            {

                var tagDB = await _context.Tags
                    .Include(t => t.User)
                    .Where(t => t.TagId == tagId
                        && t.User.CompanyId == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                if (tagDB == null)
                {
                    throw new Exception("tagNotFound");
                }

                oRetorno.Objeto = tagDB.Adapt<TagResponseDTO>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<TagResponseDTO>> ToogleStatusTagAsync(int tagId, UserClaimDTO ssn)
        {

            Retorno<TagResponseDTO> oRetorno = new();

            try
            {

                var tagDB = await _context.Tags
                    .Include(t => t.User)
                    .Where(t => t.TagId == tagId
                        && t.User.CompanyId == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                if (tagDB == null)
                {
                    throw new Exception("tagNotFound");
                }

                tagDB.IsActive = !tagDB.IsActive;

                await _context.SaveChangesAsync();

                oRetorno.Objeto = tagDB.Adapt<TagResponseDTO>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<TagResponseDTO>> UpdateTagAsync(TagRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<TagResponseDTO> oRetorno = new();

            try
            {

                var tagDB = await _context.Tags
                    .Include(t => t.User)
                    .Where(t => t.TagId == dto.TagId
                        && t.User.CompanyId == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                if (tagDB == null)
                {
                    throw new Exception("tagNotFound");
                }

                tagDB.Name = dto.Name;
                tagDB.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                oRetorno.Objeto = tagDB.Adapt<TagResponseDTO>();
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
