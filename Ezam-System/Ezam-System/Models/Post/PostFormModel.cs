using System.ComponentModel.DataAnnotations;

namespace Ezam_System.Models.Post
{
    public class PostFormModel
    {

        [Required(ErrorMessage = "Полето е задължително за попълване.")]
        [MaxLength(100, ErrorMessage = "Не може да бъде над 100 символа.")]
        [MinLength(3, ErrorMessage = "Не може да бъде под 3 символа.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Полето е задължително за попълване.")]
        [MaxLength(5000, ErrorMessage = "Не може да бъде над 5000 символа.")]
        [MinLength(3, ErrorMessage = "Не може да бъде под 3 символа.")]
        public string Message { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

    }
}
