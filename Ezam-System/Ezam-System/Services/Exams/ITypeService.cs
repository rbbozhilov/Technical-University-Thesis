using Ezam_System.Models.Exam;

namespace Ezam_System.Services.Exams
{
    public interface ITypeService
    {

        void AddType(
             string subjectName);

        bool EditType(
                      int id,
                      string subjectName);

        IEnumerable<TypeFormModelForAdmin> GetTypes();
    }
}
