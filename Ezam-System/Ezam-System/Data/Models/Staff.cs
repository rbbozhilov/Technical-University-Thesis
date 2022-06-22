using System.ComponentModel.DataAnnotations;

namespace Ezam_System.Data.Models
{
    public class Staff
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [MaxLength(200)]
        public string Position { get; set; }

        [MaxLength(20)]
        public string Office { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(2048)]
        public string ImageUrl { get; set; }

        public bool IsDeleted { get; set; }

    }
}
