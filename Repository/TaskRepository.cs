using DocumentinAPI.Data;
using DocumentinAPI.Interfaces.IRepository;

namespace DocumentinAPI.Repository
{
    public class TaskRepository : BaseRepository, ITaskRepository
    {

        public TaskRepository(DBContext context) : base(context)
        {
        }

    }
}
