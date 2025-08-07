using DocumentinAPI.Data;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Document;
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

        public async Task<Retorno<IEnumerable<DocumentResponseDTO>>> GetListDocumentValidationAsync(UserClaimDTO ssn)
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
    }
}
