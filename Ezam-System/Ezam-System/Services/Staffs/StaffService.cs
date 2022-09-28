using Ezam_System.Data;
using Ezam_System.Data.Models;
using Ezam_System.Models.Staff;
using Ezam_System.Views.ViewModels.Staff;
using System.Linq;

namespace Ezam_System.Services.Staffs
{
    public class StaffService : IStaffService
    {

        private EzamDbContext data;

        public StaffService(EzamDbContext data)
        {
            this.data = data;
        }


        public async Task CreateAsync(
                           string fullname,
                           string position,
                           string email,
                           string phoneNumber,
                           string imageUrl,
                           string office)
        {

            var newStaff = new Staff()
            {
                FullName = fullname,
                Position = position,
                Email = email,
                PhoneNumber = phoneNumber,
                ImageUrl = imageUrl,
                Office = office
            };

            await this.data.Staff.AddAsync(newStaff);

            await this.data.SaveChangesAsync();

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var currentStaff = this.data.Staff
                                        .Where(s => s.Id == id && s.IsDeleted == false)
                                        .FirstOrDefault();

            if (currentStaff == null)
            {
                return false;
            }


            currentStaff.IsDeleted = true;

            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditAsync(
                         int id,
                         string fullname,
                         string position,
                         string email,
                         string phoneNumber,
                         string imageUrl,
                         string office)
        {
            var currentStaff = this.data.Staff
                                        .Where(s => s.Id == id && s.IsDeleted == false)
                                        .FirstOrDefault();


            if (currentStaff == null)
            {
                return false;
            }

            currentStaff.FullName = fullname;
            currentStaff.Position = position;
            currentStaff.Email = email;
            currentStaff.PhoneNumber = phoneNumber;
            currentStaff.ImageUrl = imageUrl;
            currentStaff.Office = office;

            await this.data.SaveChangesAsync();

            return true;
        }

        public IEnumerable<AllStaffDetailsViewModel> GetAllStaffDetails()
        => this.data.Staff
                    .Where(s => s.IsDeleted == false)
                    .Select(s => new AllStaffDetailsViewModel()
                    {
                        Email = s.Email,
                        FullName = s.FullName,
                        ImageUrl = s.ImageUrl,
                        Office = s.Office,
                        PhoneNumber = s.PhoneNumber,
                        Position = s.Position
                    })
                    .ToList();

        public IEnumerable<StaffFormModelForAdmin> GetAllStaffForAdmin()
        => this.data.Staff
                    .Where(s => s.IsDeleted == false)
                    .Select(s => new StaffFormModelForAdmin()
                    {
                        Id = s.Id,
                        FullName = s.FullName
                    })
                    .ToList();


        public StaffFormModel GetStaffById(int id)
        => this.data.Staff
                     .Where(s => s.Id == id && s.IsDeleted == false)
                     .Select(s => new StaffFormModel()
                     {
                         FullName = s.FullName,
                         Email = s.Email,
                         PhoneNumber = s.PhoneNumber,
                         ImageUrl = s.ImageUrl,
                         Office = s.Office,
                         Position = s.Position,
                     })
                     .FirstOrDefault();


    }
}
