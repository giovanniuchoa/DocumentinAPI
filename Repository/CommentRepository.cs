using DocumentinAPI.Data;
using DocumentinAPI.Interfaces.IRepository;

namespace DocumentinAPI.Repository
{
    public class CommentRepository : BaseRepository, ICommentRepository
    {

        public CommentRepository(DBContext context) : base(context)
        {
        }

    }
}
