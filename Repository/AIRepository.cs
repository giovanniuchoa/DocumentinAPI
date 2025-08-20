using DocumentinAPI.Data;
using DocumentinAPI.Interfaces.IRepository;

namespace DocumentinAPI.Repository
{
    public class AIRepository : BaseRepository, IAIRepository
    {

        public AIRepository(DBContext context) : base(context)
        {
        }
    }
}
