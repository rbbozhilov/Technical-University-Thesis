using Ezam_System.Data;
using Ezam_System.Data.Models;
using Ezam_System.Models.Dissertation;
using Ezam_System.Views.ViewModels.Dissertation;

namespace Ezam_System.Services.Dissertations
{
    public class DissertationService : IDissertationService
    {

        private EzamDbContext data;

        public DissertationService(EzamDbContext data)
        {
            this.data = data;
        }

        public async Task CreateAsync(string fullname, int number, string supervisor)
        {
            var newDissertation = new Dissertation()
            {
                FullName = fullname,
                Number = number,
                Supervisor = supervisor
            };

            await this.data.Dissertations.AddAsync(newDissertation);

            await this.data.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var currentDissertation = this.data.Dissertations
                                       .Where(d => d.Id == id && d.IsDeleted == false)
                                       .FirstOrDefault();

            if (currentDissertation == null)
            {
                return false;
            }

            currentDissertation.IsDeleted = true;

            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditAsync(int id, string fullname, int number, string supervisor)
        {
            var currentDissertation = this.data.Dissertations
                                      .Where(d => d.Id == id && d.IsDeleted == false)
                                      .FirstOrDefault();


            if (currentDissertation == null)
            {
                return false;
            }

            currentDissertation.FullName = fullname;
            currentDissertation.Number = number;
            currentDissertation.Supervisor = supervisor;

            await this.data.SaveChangesAsync();

            return true;
        }

        public IEnumerable<AllDissertationDetailsViewModel> GetAllDissertationsDetails()
              => this.data.Dissertations
                    .Where(d => d.IsDeleted == false)
                    .Select(d => new AllDissertationDetailsViewModel()
                    {
                        Supervisor = d.Supervisor,
                        Number = d.Number,
                        FullName = d.FullName
                    })
                    .ToList();

        public IEnumerable<DissertationFormModelForAdmin> GetAllDissertationsForAdmin()
             => this.data.Dissertations
                    .Where(d => d.IsDeleted == false)
                    .Select(d => new DissertationFormModelForAdmin()
                    {
                        Id = d.Id,
                        FullName = d.FullName
                    })
                    .ToList();

        public DissertationFormModel GetDissertationById(int id)
            => this.data.Dissertations
                     .Where(d => d.Id == id && d.IsDeleted == false)
                     .Select(d => new DissertationFormModel()
                     {
                         FullName = d.FullName,
                         Number = d.Number,
                         Supervisor = d.Supervisor
                     })
                     .FirstOrDefault();

    }
}
