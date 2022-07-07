using System.ComponentModel.DataAnnotations;

namespace Ezam_System.Models.Dissertation
{
    public class DissertationFormModel
    {

        [Required(ErrorMessage = "Полето е задължително за попълване.")]
        [Range(1,2000 , ErrorMessage = "Номера трябва да е между 1 и 2000")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Полето е задължително за попълване.")]
        [MaxLength(100, ErrorMessage = "Не може да бъде над 100 символа.")]
        [MinLength(3, ErrorMessage = "Не може да бъде под 3 символа.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Полето е задължително за попълване.")]
        [MaxLength(100, ErrorMessage = "Не може да бъде над 200 символа.")]
        [MinLength(3, ErrorMessage = "Не може да бъде под 2 символа.")]
        public string Supervisor { get; set; }

    }
}
