using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.DTOs.DocumentVersion;
using DocumentinAPI.Domain.Models;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;

namespace DocumentinAPI.Services
{
    public class DocumentVersionService : IDocumentVersionService
    {

        private readonly IDocumentVersionRepository _repository;

        public DocumentVersionService(IDocumentVersionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Retorno<DocumentVersionResponseDTO>> GetDocumentVersionByIdAsync(int documentVersionId, UserSession ssn)
        {

            Retorno<DocumentVersionResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.GetDocumentVersionByIdAsync(documentVersionId, ssn);
                oRetorno = ret;

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

                var ret = await _repository.GetDocumentVersionsByDocumentIdAsync(documentId, ssn);
                oRetorno = ret;

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

                var ret = await _repository.AddDocumentVersionAsync(dto, ssn);
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
