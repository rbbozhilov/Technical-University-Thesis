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

        public async Task AddStatusAsync(string statusName)
        {
            var status = new Status()
            {
                StatusName = statusName
            };

            await this.data.Statuses.AddAsync(status);
            await this.data.SaveChangesAsync();
        }

        public async Task<bool> DeleteStatusAsync(int id)
        {
            var currentStatus = this.data.Statuses.FirstOrDefault(x => x.Id == id);

            if (currentStatus == null)
            {
                return false;
            }

            this.data.Statuses.Remove(currentStatus);
            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditStatusAsync(int id, string statusName)
        {
            var currentStatus = this.data.Statuses.FirstOrDefault(x => x.Id == id);

            if (currentStatus == null)
            {
                return false;
            }

            currentStatus.StatusName = statusName;
            await this.data.SaveChangesAsync();

            return true;
        }
    }
}
