using DocumentinAPI.Data;
using DocumentinAPI.Interfaces.IRepository;

namespace DocumentinAPI.Repository
{
    public class DocumentVersionRepository : BaseRepository, IDocumentVersionRepository
    {

        public DocumentVersionRepository(DBContext context) : base(context)
        {
        }


    }
}
