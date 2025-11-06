using DocumentinAPI.Data;
using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Comment;
using DocumentinAPI.Domain.DTOs.Email;
using DocumentinAPI.Domain.Models;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace DocumentinAPI.Repository
{
    public class CommentRepository : BaseRepository, ICommentRepository
    {

        private readonly IEmailService _emailService;

        public CommentRepository(DBContext context, IEmailService emailService) : base(context)
        {
            _emailService = emailService;
        }

        public async Task<Retorno<CommentResponseDTO>> AddCommentAsync(CommentRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<CommentResponseDTO> oRetorno = new();

            try
            {

                var commentDB = dto.Adapt<Comment>();

                commentDB.UserId = ssn.UserId;
                commentDB.CreatedAt = DateTime.Now;
                commentDB.UpdatedAt = DateTime.Now;
                commentDB.IsActive = true;

                await _context.Comments.AddAsync(commentDB);

                await _context.SaveChangesAsync();

                try
                {

                    var documentDB = await _context.Documents
                        .Include(d => d.User)
                        .Where(d => d.DocumentId == commentDB.DocumentId)
                        .FirstOrDefaultAsync();

                    var dados = new CommentEmailTemplateDTO
                    {
                        UserDocument = documentDB.User.Name,
                        UserComment = ssn.Name,
                        DocumentTitle = documentDB.Title,
                        Comment = commentDB.Content,
                        CommentDate = commentDB.CreatedAt
                    };

                    _emailService.SendEmailNewCommentToDocumentCreator(documentDB.User.Email, dados);

                }
                catch (Exception)
                {
                    throw;
                }

                oRetorno.Objeto = commentDB.Adapt<CommentResponseDTO>();
                oRetorno.SetSucesso();

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

                var commentDB = await _context.Comments
                    .Include(c => c.User)
                    .Where(c => c.CommentId == commentId
                        && c.User.CompanyId == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                if (commentDB == null)
                {
                    throw new Exception("commentNotFound");
                }

                oRetorno.Objeto = commentDB.Adapt<CommentResponseDTO>();
                oRetorno.SetSucesso();

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

                var commentDB = await _context.Comments
                    .Include(c => c.User)
                    .Where(c => c.IsActive
                        && c.User.CompanyId == ssn.CompanyId)
                    .ToListAsync();

                oRetorno.Objeto = commentDB.Adapt<List<CommentResponseDTO>>();
                oRetorno.SetSucesso();

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

                var commentDB = await _context.Comments
                    .Include(c => c.User)
                    .Where(c => c.DocumentId == documentId
                        && c.IsActive
                        && c.User.CompanyId == ssn.CompanyId)
                    .ToListAsync();

                oRetorno.Objeto = commentDB.Adapt<List<CommentResponseDTO>>();
                oRetorno.SetSucesso();

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

                var commentDB = await _context.Comments
                    .Include(c => c.User)
                    .Where(c => c.CommentId == commentId
                        && c.User.CompanyId == ssn.CompanyId)
                    .FirstOrDefaultAsync();

                if (commentDB == null)
                {
                    throw new Exception("commentNotFound");
                }

                commentDB.IsActive = !commentDB.IsActive;
                commentDB.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                oRetorno.Objeto = commentDB.Adapt<CommentResponseDTO>();
                oRetorno.SetSucesso();

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

                var commentDB = await _context.Comments
                    .Include(c => c.User)
                    .Where(c => c.CommentId == dto.CommentId
                        && c.User.CompanyId == ssn.CompanyId
                        && c.IsActive)
                    .FirstOrDefaultAsync();

                if (commentDB == null)
                {
                    throw new Exception("commentNotFound");
                }

                commentDB.Content = dto.Content;
                commentDB.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                oRetorno.Objeto = commentDB.Adapt<CommentResponseDTO>();
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
