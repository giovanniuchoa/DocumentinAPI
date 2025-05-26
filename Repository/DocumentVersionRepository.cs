using DocumentinAPI.Data;
using DocumentinAPI.Domain.DTOs.DocumentVersion;
using DocumentinAPI.Domain.Models;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DocumentinAPI.Repository
{
    public class DocumentVersionRepository : BaseRepository, IDocumentVersionRepository
    {

        public DocumentVersionRepository(DBContext context) : base(context)
        {
        }

        public async Task<Retorno<DocumentVersionResponseDTO>> GetDocumentVersionByIdAsync(int documentVersionId, UserSession ssn)
        {
            
            Retorno<DocumentVersionResponseDTO> oRetorno = new();

            try
            {

                var documentVersionDB = await _context.DocumentVersions
                    .Include(x => x.User)
                    .Where(d => d.DocumentVersionId == documentVersionId
                        && d.User.CompanyId == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                if (documentVersionDB == null)
                {
                    throw new Exception("documentVersionNotFound");
                }

                oRetorno.Objeto = documentVersionDB.Adapt<DocumentVersionResponseDTO>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<ICollection<DocumentVersionResponseDTO>>> GetDocumentVersionsByDocumentIdAsync(int documentId, UserSession ssn)
        {

            Retorno<ICollection<DocumentVersionResponseDTO>> oRetorno = new();

            try
            {

                var documentVersionListDB = await _context.DocumentVersions
                    .Include(x => x.User)
                    .Where(d => d.DocumentId == documentId
                        && d.User.CompanyId == ssn.CompanyId)
                    .ToListAsync();

                oRetorno.Objeto = documentVersionListDB.Adapt<List<DocumentVersionResponseDTO>>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<DocumentVersionResponseDTO>> AddDocumentVersionAsync(DocumentVersionRequestDTO dto, UserSession ssn)
        {

            Retorno<DocumentVersionResponseDTO> oRetorno = new();

            try
            {

                var documentVersionDB = dto.Adapt<DocumentVersion>();

                documentVersionDB.CreatedAt = DateTime.Now;
                documentVersionDB.UpdatedAt = DateTime.Now;
                documentVersionDB.UserId = ssn.UserId;

                await _context.DocumentVersions.AddAsync(documentVersionDB);

                await _context.SaveChangesAsync();

                oRetorno.Objeto = documentVersionDB.Adapt<DocumentVersionResponseDTO>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<DocumentVersionResponseDTO>> AddCommentDocumentVersionAsync(DocumentVersionAddCommentRequestDTO dto, UserSession ssn)
        {

            Retorno<DocumentVersionResponseDTO> oRetorno = new();

            try
            {

                var documentVersionDB = await _context.DocumentVersions
                    .Where(d => d.User.CompanyId == ssn.CompanyId
                        && d.DocumentVersionId == dto.DocumentVersionId)
                    .FirstOrDefaultAsync();

                if (documentVersionDB == null)
                {
                    throw new Exception("documentVersionNotFound");
                }

                documentVersionDB.Comment = dto.Comment;
                documentVersionDB.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                oRetorno.Objeto = documentVersionDB.Adapt<DocumentVersionResponseDTO>();
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
