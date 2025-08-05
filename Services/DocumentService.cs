using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;
using DocumentinAPI.Domain.DTOs.Auth;

namespace DocumentinAPI.Services
{
    public class DocumentService : IDocumentService
    {

        private readonly IDocumentRepository _repository;

        public DocumentService(IDocumentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Retorno<DocumentResponseDTO>> AddDocumentAsync(DocumentRequestDTO document, UserClaimDTO ssn)
        {
            
            Retorno<DocumentResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.AddDocumentAsync(document, ssn);
                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<DocumentResponseDTO>> GetDocumentByIdAsync(int documentId, UserClaimDTO ssn)
        {
            
            Retorno<DocumentResponseDTO> oRetorno = new();

            try
            {
                var ret = await _repository.GetDocumentByIdAsync(documentId, ssn);
                oRetorno = ret;
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
                var ret = await _repository.GetListDocumentAsync(ssn);
                oRetorno = ret;
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
                var ret = await _repository.ToogleStatusDocumentAsync(documentId, ssn);
                oRetorno = ret;
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
                var ret = await _repository.UpdateDocumentAsync(document, ssn);
                oRetorno = ret;
            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }
    }
}
