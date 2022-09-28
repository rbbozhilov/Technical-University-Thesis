using Ezam_System.Models.Exam;

namespace Ezam_System.Services.Exams
{
    public interface ITypeService
    {

        Task AddTypeAsync(
             string subjectName);

        Task<bool> EditTypeAsync(
                      int id,
                      string subjectName);

        IEnumerable<TypeFormModelForAdmin> GetTypes();
    }
}
