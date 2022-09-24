using System.ComponentModel.DataAnnotations;

namespace Ezam_System.Models.Exam
{
    public class StatusFormModel
    {

        [MaxLength(20)]
        public string StatusName { get; set; }

    }
}
