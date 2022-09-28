using Ezam_System.Models.Exam;
using Ezam_System.Views.ViewModels.Exam;

namespace Ezam_System.Services.Exams
{
    public interface IExamService
    {

        Task AddExamAsync(
                     string hall,
                     DateTime date,
                     DateTime time,
                     int typeId,
                     int statusId);

        Task<bool> EditExamAsync(
                      int id,
                      string hall,
                      DateTime date,
                      DateTime time,
                      int statusId);

        Task<bool> DeleteExamAsync(int id);

        bool IsHaveType(int typeId);

        bool isHaveStatus(int statusId);

        ExamEditFormModel GetExamById(int id);

        IEnumerable<string> Types();

        IEnumerable<TypeViewModel> GetAllTypes();

        IEnumerable<StatusViewModel> GetAllStatuses();

        IEnumerable<InformationViewModel> GetInformation(string type);

        IEnumerable<ExamFormModelForAdmin> GetExamsForAdminView();
    }
}
