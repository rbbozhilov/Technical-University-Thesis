using Ezam_System.Views.ViewModels.Exam;

namespace Ezam_System.Services.Exams
{
    public interface IExamService
    {

        void AddExam(
                     string hall,
                     DateTime date,
                     DateTime time,
                     int typeId,
                     int statusId);

        bool EditExam(
                      int id,
                      string hall,
                      DateTime date,
                      DateTime time,
                      int typeId,
                      int statusId);

        bool DeleteExam(int id);

        bool IsHaveType(int typeId);

        bool isHaveStatus(int statusId);


        IEnumerable<string> Types();

        IEnumerable<TypeViewModel> GetAllTypes();

        IEnumerable<StatusViewModel> GetAllStatuses();

        IEnumerable<InformationViewModel> GetInformation(string type);

    }
}
