using DocumentinAPI.Data;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.DTOs.DocumentValidation;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DocumentinAPI.Repository
{
    public class DocumentValidationRepository : BaseRepository, IDocumentValidationRepository
    {

        public DocumentValidationRepository(DBContext context) : base(context)
        {
        }

        public async Task<Retorno<IEnumerable<DocumentResponseDTO>>> GetListDocumentValidationByValidatorAsync(UserClaimDTO ssn)
        {

            Retorno<IEnumerable<DocumentResponseDTO>> oRetorno = new();

            try
            {

                var documentsIdsToValidate = await _context.DocumentValidations
                    .Include(d => d.Folder)
                    .Where(d => d.Folder.ValidatorId == ssn.UserId
                        && d.Status == (short)Enums.StatusValidacao.EmAndamento)
                    .Select(D => D.DocumentId)
                    .ToListAsync();

                var documentsDB = await _context.Documents
                    .Where(d => documentsIdsToValidate.Contains(d.DocumentId)
                        && d.User.CompanyId == ssn.CompanyId
                        && d.IsActive)
                    .ToListAsync();

                oRetorno.Objeto = documentsDB.Adapt<IEnumerable<DocumentResponseDTO>>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<IEnumerable<DocumentResponseDTO>>> GetListDocumentValidationToEditAsync(UserClaimDTO ssn)
        {

            Retorno<IEnumerable<DocumentResponseDTO>> oRetorno = new();

            try
            {

                var documentsIdsToEdit = await _context.DocumentValidations
                    .Where(d => d.UserId == ssn.UserId
                        && d.Status == (short)Enums.StatusValidacao.Retornado)
                    .Select(D => D.DocumentId)
                    .ToListAsync();

                var documentsDB = await _context.Documents
                    .Where(d => documentsIdsToEdit.Contains(d.DocumentId)
                        && d.User.CompanyId == ssn.CompanyId
                        && d.IsActive)
                    .ToListAsync();

                oRetorno.Objeto = documentsDB.Adapt<IEnumerable<DocumentResponseDTO>>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<DocumentValidationResponseDTO>> UpdateDocumentValidationStatusAsync(DocumentValidationRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<DocumentValidationResponseDTO> oRetorno = new();

            try
            {

                var documentValidationDB = await _context.DocumentValidations
                    .Where(d => d.DocumentId == dto.DocumentId)
                    .FirstOrDefaultAsync();

                documentValidationDB.Status = dto.Status;
                documentValidationDB.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                if (dto.Status == (short)Enums.StatusValidacao.Validado)
                {

                    var documentDB = await _context.Documents
                        .Where(d => d.DocumentId == dto.DocumentId)
                        .FirstOrDefaultAsync();

                    documentDB.IsValid = true;  

                    await _context.SaveChangesAsync();

                }

                oRetorno.Objeto = documentValidationDB.Adapt<DocumentValidationResponseDTO>();
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
