using System.ComponentModel.DataAnnotations;

namespace Ezam_System.Data.Models.Exam
{
    public class Status
    {

        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        public string StatusName { get; set; }

    }
}
