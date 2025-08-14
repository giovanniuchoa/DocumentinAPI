using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Comment;
using DocumentinAPI.Domain.DTOs.Company;
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

            Retorno<CommentResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.AddCommentAsync(dto, ssn);

                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<CommentResponseDTO>> GetCommentByIdAsync(int commentId, UserClaimDTO ssn)
        {

            Retorno<CommentResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.GetCommentByIdAsync(commentId, ssn);

                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<IEnumerable<CommentResponseDTO>>> GetListCommentAsync(UserClaimDTO ssn)
        {

            Retorno<IEnumerable<CommentResponseDTO>> oRetorno = new();

            try
            {

                var ret = await _repository.GetListCommentAsync(ssn);

                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<IEnumerable<CommentResponseDTO>>> GetListCommentByDocumentIdAsync(int documentId, UserClaimDTO ssn)
        {

            Retorno<IEnumerable<CommentResponseDTO>> oRetorno = new();

            try
            {

                var ret = await _repository.GetListCommentByDocumentIdAsync(documentId, ssn);

                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<CommentResponseDTO>> ToogleStatusCommentAsync(int commentId, UserClaimDTO ssn)
        {

            Retorno<CommentResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.ToogleStatusCommentAsync(commentId, ssn);

                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }

        public async Task<Retorno<CommentResponseDTO>> UpdateCommentAsync(CommentRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<CommentResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.UpdateCommentAsync(dto, ssn);

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
