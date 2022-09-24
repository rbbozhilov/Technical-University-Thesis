namespace Ezam_System.Views.ViewModels.Exam
{
    public class ExamViewModel
    {

        public string Type { get; set; }

        public IEnumerable<string> Types { get; set; }

        public IEnumerable<InformationViewModel> ExamInformation { get; set; }


    }
}
