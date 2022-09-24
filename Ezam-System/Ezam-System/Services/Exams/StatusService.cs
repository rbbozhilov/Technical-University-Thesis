using Ezam_System.Data;
using Ezam_System.Data.Models.Exam;

namespace Ezam_System.Services.Exams
{
    public class StatusService : IStatusService
    {

        private EzamDbContext data;

        public StatusService(EzamDbContext data)
        {
            this.data = data;
        }

        public void AddStatus(string statusName)
        {
            var status = new Status()
            {
                StatusName = statusName
            };

            this.data.Statuses.Add(status);
            this.data.SaveChanges();
        }

        public bool DeleteStatus(int id)
        {
            var currentStatus = this.data.Statuses.FirstOrDefault(x => x.Id == id);

            if (currentStatus == null)
            {
                return false;
            }

            this.data.Statuses.Remove(currentStatus);
            this.data.SaveChanges();

            return true;
        }

        public bool EditStatus(int id, string statusName)
        {
            var currentStatus = this.data.Statuses.FirstOrDefault(x => x.Id == id);

            if (currentStatus == null)
            {
                return false;
            }

            currentStatus.StatusName = statusName;
            this.data.SaveChanges();

            return true;
        }
    }
}
