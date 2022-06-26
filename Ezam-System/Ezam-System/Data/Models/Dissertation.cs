using System.ComponentModel.DataAnnotations;

namespace Ezam_System.Data.Models
{
    public class Dissertation
    {
        [Key]
        public int Id { get; set; }

        public int Number { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Supervisor { get; set; }

        public bool IsDeleted { get; set; }
    }
}
