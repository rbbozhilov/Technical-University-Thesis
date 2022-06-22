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


    }
}
