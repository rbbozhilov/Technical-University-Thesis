namespace Ezam_System.Services.Exams
{
    public interface IStatusService
    {


        Task AddStatusAsync(
             string statusName);

        Task<bool> EditStatusAsync(
                      int id,
                      string statusName);

        Task<bool> DeleteStatusAsync(int id);

    }
}
