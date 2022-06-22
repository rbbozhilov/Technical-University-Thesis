using Ezam_System.Data;
using Ezam_System.Data.Models;
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


        public void Create(
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

            this.data.Staff.Add(newStaff);

            this.data.SaveChanges();

        }

        public bool Delete(int id)
        {
            var currentStaff = this.data.Staff
                                        .Where(s => s.Id == id && s.IsDeleted == false)
                                        .FirstOrDefault();

            if(currentStaff == null)
            {
                return false;
            }


            currentStaff.IsDeleted = true;

            this.data.SaveChanges();

            return true;
        }

        public bool Edit(
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


            if(currentStaff == null)
            {
                return false;
            }

            currentStaff.FullName = fullname;
            currentStaff.Position = position;
            currentStaff.Email = email;
            currentStaff.PhoneNumber = phoneNumber;
            currentStaff.ImageUrl = imageUrl;
            currentStaff.Office = office;

            return true;
        }
    }
}
