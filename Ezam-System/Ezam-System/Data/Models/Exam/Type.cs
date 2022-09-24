using System.ComponentModel.DataAnnotations;

namespace Ezam_System.Data.Models.Exam
{
    public class Type
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string SubjectName { get; set; }

    }
}
