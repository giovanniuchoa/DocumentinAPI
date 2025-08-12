using DocumentinAPI.Data;
using DocumentinAPI.Interfaces.IRepository;

namespace DocumentinAPI.Repository
{
    public class TemplateRepository : BaseRepository, ITemplateRepository
    {

        public TemplateRepository(DBContext context) : base(context)
        {
        }

    }
}
