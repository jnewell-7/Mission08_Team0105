using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0105.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        public DbSet<Task> Tasks { get; set; }
        
        public DbSet<Quadrant> Quadrants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quadrant>().HasData(
                new Quadrant {QuadrantId = 1, QuadrantName = "Important/Urgent"},
                new Quadrant {QuadrantId = 2, QuadrantName = "Important/Not Urgent"},
                new Quadrant {QuadrantId = 3, QuadrantName = "Not Important/Urgent"},
                new Quadrant {QuadrantId = 4, QuadrantName = "Not Important/Not Urgent"}
              
            );
        }

    }
}
