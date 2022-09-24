namespace Ezam_System.Views.ViewModels.Exam
{
    public class ExamViewModel
    {

        public IEnumerable<Data.Models.Exam.Type> Types { get; set; }

        public IEnumerable<InformationViewModel> ExamInformation { get; set; }


    }
}
