using DocumentinAPI.Data;
using DocumentinAPI.Interfaces.IRepository;

namespace DocumentinAPI.Repository
{
    public class DocumentRepository : BaseRepository, IDocumentRepository
    {
        public DocumentRepository(DBContext context) : base(context)
        {
        }
    }
}
