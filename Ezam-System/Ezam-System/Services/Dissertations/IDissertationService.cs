using Ezam_System.Models.Dissertation;
using Ezam_System.Views.ViewModels.Dissertation;

namespace Ezam_System.Services.Dissertations
{
    public interface IDissertationService
    {

        Task CreateAsync(
                  string fullname,
                  int number,
                  string supervisor);


        Task<bool> EditAsync(
                  int id,
                  string fullname,
                  int number,
                  string supervisor);

        Task<bool> DeleteAsync(int id);

        DissertationFormModel GetDissertationById(int id);

        IEnumerable<DissertationFormModelForAdmin> GetAllDissertationsForAdmin();

        IEnumerable<AllDissertationDetailsViewModel> GetAllDissertationsDetails();

    }
}
