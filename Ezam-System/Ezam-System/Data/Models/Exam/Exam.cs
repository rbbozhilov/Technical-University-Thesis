using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ezam_System.Data.Models.Exam
{
    public class Exam
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }

        public Type Type { get; set; }

        [ForeignKey(nameof(Status))]
        public int StatusId { get; set; }

        public Status Status { get; set; }

    }
}
