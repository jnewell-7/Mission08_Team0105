using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0105.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        
        [Required]
        public string TaskName { get; set; } 
        
        public string? DueDate { get; set; }
        
        [Required]
        public string QuadrantName { get; set; }
        
        public bool Completed { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        
        public virtual Category? Category { get; set; }

    }
}
