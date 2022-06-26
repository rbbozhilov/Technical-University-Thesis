using Ezam_System.Models.Dissertation;
using Ezam_System.Views.ViewModels.Dissertation;

namespace Ezam_System.Services.Dissertations
{
    public interface IDissertationService
    {

        void Create(
                  string fullname,
                  int number,
                  string supervisor);


        bool Edit(
                  int id,
                  string fullname,
                  int number,
                  string supervisor);

        bool Delete(int id);

        DissertationFormModel GetDissertationById(int id);

        IEnumerable<DissertationFormModelForAdmin> GetAllDissertationsForAdmin();

        IEnumerable<AllDissertationDetailsViewModel> GetAllDissertationsDetails();

    }
}
