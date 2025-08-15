using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.DTOs.Tag;
using DocumentinAPI.Domain.DTOs.Template;
using DocumentinAPI.Domain.Models;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;
using System.Reflection.Metadata;

namespace DocumentinAPI.Services
{
    public class TagService : ITagService
    {

        private readonly ITagRepository _repository;

        public TagService(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<Retorno<DocumentXTagResponseDTO>> AddDocumentXTagAsync(DocumentXTagRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<DocumentXTagResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.AddDocumentXTagAsync(dto, ssn);
                oRetorno = ret;

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

                var ret = await _repository.AddTagAsync(dto, ssn);
                oRetorno = ret;

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

                var ret = await _repository.DeleteDocumentXTagAsync(dto, ssn);
                oRetorno = ret;

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

                var ret = await _repository.GetDocumentXTagByDocumentIdAsync(documentId, ssn);
                oRetorno = ret;

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

                var ret = await _repository.GetDocumentXTagByTagIdAsync(tagId, ssn);
                oRetorno = ret;

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

                var ret = await _repository.GetListTagAsync(ssn);
                oRetorno = ret;

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

                var ret = await _repository.GetTagByIdAsync(tagId, ssn);
                oRetorno = ret;

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

                var ret = await _repository.ToogleStatusTagAsync(tagId, ssn);
                oRetorno = ret;

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

                var ret = await _repository.UpdateTagAsync(dto, ssn);
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
