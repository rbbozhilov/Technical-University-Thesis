using System.ComponentModel.DataAnnotations;

namespace Ezam_System.Models.Exam
{
    public class TypeFormModel
    {
        [Required]
        [MaxLength(100)]
        public string SubjectName { get; set; }

    }
}
