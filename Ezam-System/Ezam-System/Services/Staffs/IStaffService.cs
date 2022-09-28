using Ezam_System.Models.Staff;
using Ezam_System.Views.ViewModels.Staff;

namespace Ezam_System.Services.Staffs
{
    public interface IStaffService
    {

        Task CreateAsync(
                  string fullname,
                  string position,
                  string email,
                  string phoneNumber,
                  string imageUrl,
                  string office);


        Task<bool> EditAsync(
                  int id,
                  string fullname,
                  string position,
                  string email,
                  string phoneNumber,
                  string imageUrl,
                  string office);

        Task<bool> DeleteAsync(int id);

        StaffFormModel GetStaffById(int id);

        IEnumerable<StaffFormModelForAdmin> GetAllStaffForAdmin();

        IEnumerable<AllStaffDetailsViewModel> GetAllStaffDetails();
    }
}
