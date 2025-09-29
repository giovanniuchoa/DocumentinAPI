using DocumentinAPI.Data;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.DTOs.Email;
using DocumentinAPI.Domain.Models;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DocumentinAPI.Repository
{
    public class DocumentRepository : BaseRepository, IDocumentRepository
    {

        private readonly IEmailService _emailService;

        public DocumentRepository(DBContext context, IEmailService emailService) : base(context)
        {
            _emailService = emailService;
        }

        public async Task<Retorno<DocumentResponseDTO>> GetDocumentByIdAsync(int documentId, UserClaimDTO ssn)
        {

            Retorno<DocumentResponseDTO> oRetorno = new();

            try
            {

                var documentoDB = await _context.Documents
                    .Include(d => d.User)
                    .Where(d => d.DocumentId == documentId
                        && d.User.CompanyId == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                if (documentoDB == null)
                {
                    throw new Exception("notFound");
                }

                var documento = documentoDB.Adapt<DocumentResponseDTO>();


                oRetorno.Objeto = documento;
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<IEnumerable<DocumentResponseDTO>>> GetListDocumentAsync(UserClaimDTO ssn)
        {

            Retorno<IEnumerable<DocumentResponseDTO>> oRetorno = new();

            try
            {

                var documentListDB = await _context.Documents
                    .Include(d => d.User)
                    .Where(d => d.User.CompanyId == ssn.CompanyId
                        && d.IsValid == true
                        && ssn.FoldersIdsList.Contains(d.FolderId))
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

        public async Task<Retorno<DocumentResponseDTO>> AddDocumentAsync(DocumentRequestDTO document, UserClaimDTO ssn)
        {
            
            Retorno<DocumentResponseDTO> oRetorno = new();

            try
            {

                var documentoDB = await _context.Documents
                    .Where(d => d.DocumentId == document.DocumentId)
                    .FirstOrDefaultAsync();

                if (documentoDB != null)
                {
                    throw new Exception("documentAlreadyExists");
                }

                var folderDB = await _context.Folders
                    .Include(f => f.Validator)
                    .Include(f => f.User)
                    .Where(f => f.FolderId == document.FolderId
                        && f.User.CompanyId == ssn.CompanyId
                        && f.IsActive == true)
                    .FirstOrDefaultAsync();

                if (folderDB == null)
                {
                    throw new Exception("folderNotFound");
                }

                documentoDB = document.Adapt<Domain.Models.Document>();

                documentoDB.UserId = ssn.UserId;
                documentoDB.CreatedAt = DateTime.Now;
                documentoDB.UpdatedAt = DateTime.Now;
                documentoDB.IsActive = true;

                await _context.Documents.AddAsync(documentoDB);
                await _context.SaveChangesAsync();

                try
                {

                    /* Grava na DocumentVersion */

                    var documentVersionDB = new DocumentVersion
                    {
                        DocumentId = documentoDB.DocumentId,
                        Content = documentoDB.Content,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        UserId = ssn.UserId
                    };

                    await _context.DocumentVersions.AddAsync(documentVersionDB);

                    await _context.SaveChangesAsync();

                }
                catch (Exception)
                {
                    throw;
                }

                try
                {

                    /* Grava na DocumentValidation */

                    var documentValidationDB = new DocumentValidation
                    {
                        DocumentId = documentoDB.DocumentId,
                        FolderId = documentoDB.FolderId,
                        Status = (short)Enums.StatusValidacao.EmAndamento,    
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        UserId = ssn.UserId
                    };

                    await _context.DocumentValidations.AddAsync(documentValidationDB);

                    await _context.SaveChangesAsync();

                }
                catch (Exception)
                {
                    throw;
                }

                try
                {

                    /* Envia email para o validador e criador */

                    var validatorEmail = await _context.Users
                        .Where(u => u.UserId == folderDB.ValidatorId)
                        .Select(u => u.Email)
                        .FirstOrDefaultAsync();

                    var dados = new DocumentEmailTemplateDTO
                    {
                        Title = documentoDB.Title,
                        Username = ssn.Name,
                        FolderName = folderDB.Name,
                        CreatedAt = documentoDB.CreatedAt
                    };

                    await _emailService.SendEmailNewDocumentToValidator(validatorEmail, dados);

                    dados.Username = folderDB.Validator.Name;

                    await _emailService.SendEmailNewDocumentToCreator(documentoDB.User.Email, dados);

                }
                catch (Exception)
                {
                    throw;
                }

                oRetorno.Objeto = documentoDB.Adapt<DocumentResponseDTO>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<DocumentResponseDTO>> UpdateDocumentAsync(DocumentRequestDTO document, UserClaimDTO ssn)
        {
            
            Retorno<DocumentResponseDTO> oRetorno = new();

            try
            {

                var documentoDB = await _context.Documents
                    .Include(d => d.User)
                    .Where(d => d.DocumentId == document.DocumentId
                        && d.User.CompanyId == ssn.CompanyId
                        && d.IsActive == true)
                    .FirstOrDefaultAsync();

                if (documentoDB == null)
                {
                    throw new Exception("notFound");
                }

                var folderDB = await _context.Folders
                    .Include(f => f.User)
                    .Where(f => f.FolderId == document.FolderId
                        && f.User.CompanyId == ssn.CompanyId
                        && f.IsActive == true)
                    .FirstOrDefaultAsync();

                if (folderDB == null)
                {
                    throw new Exception("folderNotFound");
                }

                documentoDB.Title = document.Title;
                documentoDB.Content = document.Content;
                documentoDB.UpdatedAt = DateTime.Now;
                documentoDB.FolderId = document.FolderId;

                await _context.SaveChangesAsync();

                try
                {

                    /* Grava na DocumentVersion */

                    var documentVersionDB = new DocumentVersion
                    {
                        DocumentId = documentoDB.DocumentId,
                        Content = documentoDB.Content,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        UserId = ssn.UserId
                    };

                    await _context.DocumentVersions.AddAsync(documentVersionDB);

                    await _context.SaveChangesAsync();

                }
                catch (Exception)
                {
                    throw;
                }

                oRetorno.Objeto = documentoDB.Adapt<DocumentResponseDTO>();
                oRetorno.SetSucesso();

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<DocumentResponseDTO>> ToogleStatusDocumentAsync(int documentId, UserClaimDTO ssn)
        {
            
            Retorno<DocumentResponseDTO> oRetorno = new();

            try
            {

                var documentoDB = await _context.Documents
                    .Include(d => d.User)
                    .Where(d => d.DocumentId == documentId
                        && d.User.CompanyId == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                if (documentoDB == null)
                {
                    throw new Exception("notFound");
                }

                documentoDB.IsActive = !documentoDB.IsActive;
                documentoDB.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                oRetorno.Objeto = documentoDB.Adapt<DocumentResponseDTO>();
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
