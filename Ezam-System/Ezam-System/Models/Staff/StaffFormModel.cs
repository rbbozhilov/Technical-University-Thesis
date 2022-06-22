using System.ComponentModel.DataAnnotations;

namespace Ezam_System.Models.Staff
{
    public class StaffFormModel
    {

        [Required(ErrorMessage = "Полето е задължително за попълване.")]
        [MaxLength(100,ErrorMessage = "Не може да бъде над 100 символа.")]
        [MinLength(3, ErrorMessage = "Не може да бъде под 3 символа.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Полето е задължително за попълване.")]
        [MaxLength(200,ErrorMessage = "Не може да бъде над 200 символа.")]
        [MinLength(2, ErrorMessage = "Не може да бъде под 2 символа.")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Полето е задължително за попълване.")]
        [MaxLength(20, ErrorMessage = "Не може да бъде над 20 символа.")]
        [MinLength(2, ErrorMessage = "Не може да бъде под 2 символа.")]
        public string Office { get; set; }

        [Required(ErrorMessage = "Полето е задължително за попълване.")]
        [MaxLength(20, ErrorMessage = "Не може да бъде над 20 символа.")]
        [MinLength(3, ErrorMessage = "Не може да бъде под 3 символа.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Полето е задължително за попълване.")]
        [MaxLength(50, ErrorMessage = "Не може да бъде над 50 символа.")]
        [MinLength(3, ErrorMessage = "Не може да бъде под 3 символа.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Полето е задължително за попълване.")]
        [MaxLength(2048, ErrorMessage = "Не може да бъде над 2048 символа.")]
        [Url]
        public string ImageUrl { get; set; }

    }
}
