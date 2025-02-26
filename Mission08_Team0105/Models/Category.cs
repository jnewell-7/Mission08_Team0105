using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0105.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
