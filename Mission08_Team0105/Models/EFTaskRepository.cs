
namespace Mission08_Team0105.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private TaskContext _context;
        public EFTaskRepository(TaskContext temp)
        {
            _context = temp;
        }
        public List<Task> Task => _context.Tasks.ToList();
    }
}
