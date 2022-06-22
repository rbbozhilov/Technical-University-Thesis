using System.ComponentModel.DataAnnotations;

namespace Ezam_System.Data.Models
{
    public class Staff
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Office { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }


    }
}
