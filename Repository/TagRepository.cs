using DocumentinAPI.Data;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.DTOs.Tag;
using DocumentinAPI.Domain.Models;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace DocumentinAPI.Repository
{
    public class TagRepository : BaseRepository, ITagRepository
    {
        public TagRepository(DBContext context) : base(context)
        {
        }

        public async Task<Retorno<DocumentXTagResponseDTO>> AddDocumentXTagAsync(DocumentXTagRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<DocumentXTagResponseDTO> oRetorno = new();

            try
            {

                var documentoDB = await _context.Documents
                    .Include(d => d.User)
                    .Where(d => d.DocumentId == dto.DocumentId
                        && d.User.CompanyId == ssn.CompanyId
                        && d.IsActive
                        && d.IsValid == true)
                    .FirstOrDefaultAsync();

                if (documentoDB == null)
                {
                    throw new Exception("documentNotFound");
                }

                var tagDB = await _context.Tags
                    .Include(t => t.User)
                    .Where(t => t.TagId == dto.TagId
                        && t.User.CompanyId == ssn.CompanyId
                        && t.IsActive)
                    .FirstOrDefaultAsync();

                if (tagDB == null)
                {
                    throw new Exception("tagNotFound");
                }

                var documentXTagDB = new DocumentXTag();

                documentXTagDB.DocumentId = dto.DocumentId;
                documentXTagDB.TagId = dto.TagId;
                documentXTagDB.CreatedAt = DateTime.Now;
                documentXTagDB.UserId = ssn.UserId;

                await _context.DocumentXTags.AddAsync(documentXTagDB);

                await _context.SaveChangesAsync();

                oRetorno.Objeto = documentXTagDB.Adapt<DocumentXTagResponseDTO>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

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
                tagDB.IsActive = true;

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

        public async Task<Retorno<IEnumerable<TagResponseDTO>>> GetDocumentXTagByDocumentIdAsync(int documentId, UserClaimDTO ssn)
        {

            Retorno<IEnumerable<TagResponseDTO>> oRetorno = new();

            try
            {

                var tagListDB = await _context.DocumentXTags
                    .Include(dxt => dxt.Tag)
                    .Where(dxt => dxt.DocumentId == documentId
                        && dxt.Tag.IsActive)
                    .Select(dxt => dxt.Tag)
                    .ToListAsync();

                oRetorno.Objeto = tagListDB.Adapt<List<TagResponseDTO>>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<IEnumerable<DocumentResponseDTO>>> GetDocumentXTagByTagIdAsync(int tagId, UserClaimDTO ssn)
        {
            Retorno<IEnumerable<DocumentResponseDTO>> oRetorno = new();

            try
            {

                var documentListDB = await _context.DocumentXTags
                    .Include(dxt => dxt.Document)
                    .Where(dxt => dxt.TagId == tagId
                        && dxt.Document.IsActive 
                        && dxt.Document.IsValid == true)
                    .Select(dxt => dxt.Document)
                    .ToListAsync();

                oRetorno.Objeto = documentListDB.Adapt<List<DocumentResponseDTO>>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

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

        public async Task<Retorno<IEnumerable<TagResponseDTO>>> DeleteDocumentXTagAsync(DocumentXTagRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<IEnumerable<TagResponseDTO>> oRetorno = new();

            try
            {

                var documentXTagDB = await _context.DocumentXTags
                    .Where(dxt => dxt.DocumentId == dto.DocumentId && dxt.TagId == dto.TagId)
                    .FirstOrDefaultAsync();

                if (documentXTagDB == null)
                {
                    throw new Exception("documentXTagNotFound");
                }

                _context.DocumentXTags.Remove(documentXTagDB);

                await _context.SaveChangesAsync();

                var tagListDB = await _context.DocumentXTags
                    .Include(dxt => dxt.Tag)
                    .Where(dxt => dxt.DocumentId == dto.DocumentId)
                    .Select(dxt => dxt.Tag)
                    .ToListAsync();

                oRetorno.Objeto = tagListDB.Adapt<List<TagResponseDTO>>();
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
