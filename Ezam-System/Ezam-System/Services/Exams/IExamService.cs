using Ezam_System.Views.ViewModels.Exam;

namespace Ezam_System.Services.Exams
{
    public interface IExamService
    {

        IEnumerable<string> Types();

        IEnumerable<InformationViewModel> GetInformation(string type);

    }
}
