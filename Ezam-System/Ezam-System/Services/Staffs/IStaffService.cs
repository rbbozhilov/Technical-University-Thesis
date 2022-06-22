using Ezam_System.Models.Staff;
using Ezam_System.Views.ViewModels.Staff;

namespace Ezam_System.Services.Staffs
{
    public interface IStaffService
    {

        void Create(
                  string fullname,
                  string position,
                  string email,
                  string phoneNumber,
                  string imageUrl,
                  string office);


        bool Edit(
                  int id,
                  string fullname,
                  string position,
                  string email,
                  string phoneNumber,
                  string imageUrl,
                  string office);

        bool Delete(int id);

        StaffFormModel GetStaffById(int id);

        IEnumerable<StaffFormModelForAdmin> GetAllStaffForAdmin();

        IEnumerable<AllStaffDetailsViewModel> GetAllStaffDetails();
    }
}
