namespace Ezam_System.Services.Exams
{
    public interface IStatusService
    {


        void AddStatus(
             string statusName);

        bool EditStatus(
                      int id,
                      string statusName);

        bool DeleteStatus(int id);

    }
}
