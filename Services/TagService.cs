using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.DTOs.Tag;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;

namespace DocumentinAPI.Services
{
    public class TagService : ITagService
    {

        private readonly ITagRepository _repository;

        public TagService(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<Retorno<DocumentXTagResponseDTO>> AddDocumentXTagAsync(int documentId, int tagId, UserClaimDTO ssn)
        {
            throw new NotImplementedException();
        }

        public async Task<Retorno<TagResponseDTO>> AddTagAsync(TagRequestDTO dto, UserClaimDTO ssn)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public async Task<Retorno<TagResponseDTO>> GetTagByIdAsync(int tagId, UserClaimDTO ssn)
        {
            throw new NotImplementedException();
        }

        public async Task<Retorno<TagResponseDTO>> ToogleStatusTagAsync(int tagId, UserClaimDTO ssn)
        {
            throw new NotImplementedException();
        }

        public async Task<Retorno<TagResponseDTO>> UpdateTagAsync(TagRequestDTO dto, UserClaimDTO ssn)
        {
            throw new NotImplementedException();
        }

    }
}
