using Ezam_System.Views.ViewModels.Exam;
using System.ComponentModel.DataAnnotations;

namespace Ezam_System.Models.Exam
{
    public class ExamEditFormModel
    {

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(50)]
        public string Hall { get; set; }

        [Required]
        public DateTime Time { get; set; }

        public int StatusId { get; set; }

        public IEnumerable<StatusViewModel>? Status { get; set; }
    }
}
