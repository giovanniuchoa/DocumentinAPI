using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Comment;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;

namespace DocumentinAPI.Services
{
    public class CommentService : ICommentService
    {

        private readonly ICommentRepository _repository;

        public CommentService(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Retorno<CommentResponseDTO>> AddCommentAsync(CommentRequestDTO dto, UserClaimDTO ssn)
        {
            throw new NotImplementedException();
        }

        public async Task<Retorno<CommentResponseDTO>> GetCommentByIdAsync(int commentId, UserClaimDTO ssn)
        {
            throw new NotImplementedException();
        }

        public async Task<Retorno<IEnumerable<CommentResponseDTO>>> GetListCommentAsync(UserClaimDTO ssn)
        {
            throw new NotImplementedException();
        }

        public async Task<Retorno<IEnumerable<CommentResponseDTO>>> GetListCommentByDocumentIdAsync(int documentId, UserClaimDTO ssn)
        {
            throw new NotImplementedException();
        }

        public async Task<Retorno<CommentResponseDTO>> ToogleStatusCommentAsync(int commentId, UserClaimDTO ssn)
        {
            throw new NotImplementedException();
        }

        public async Task<Retorno<CommentResponseDTO>> UpdateCommentAsync(CommentRequestDTO dto, UserClaimDTO ssn)
        {
            throw new NotImplementedException();
        }
    }
}
