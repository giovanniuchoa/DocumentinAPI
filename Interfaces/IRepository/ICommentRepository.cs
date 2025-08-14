using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Comment;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IRepository
{
    public interface ICommentRepository
    {

        public Task<Retorno<CommentResponseDTO>> GetCommentByIdAsync(int commentId, UserClaimDTO ssn);
        public Task<Retorno<IEnumerable<CommentResponseDTO>>> GetListCommentAsync(UserClaimDTO ssn);
        public Task<Retorno<IEnumerable<CommentResponseDTO>>> GetListCommentByDocumentIdAsync(int documentId, UserClaimDTO ssn);
        public Task<Retorno<CommentResponseDTO>> AddCommentAsync(CommentRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<CommentResponseDTO>> UpdateCommentAsync(CommentRequestDTO dto, UserClaimDTO ssn);
        public Task<Retorno<CommentResponseDTO>> ToogleStatusCommentAsync(int commentId, UserClaimDTO ssn);

    }
}
