using System.ComponentModel.DataAnnotations;

namespace Ezam_System.Data.Models
{
    public class Post
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Message { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public bool IsDeleted { get; set; }
    }
}
