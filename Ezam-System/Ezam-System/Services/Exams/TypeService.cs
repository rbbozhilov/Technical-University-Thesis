using Ezam_System.Data;
using Ezam_System.Models.Exam;

namespace Ezam_System.Services.Exams
{
    public class TypeService : ITypeService
    {

        private EzamDbContext data;

        public TypeService(EzamDbContext data)
        {
            this.data = data;
        }


        public async Task AddTypeAsync(string subjectName)
        {
            var type = new Ezam_System.Data.Models.Exam.Type()
            {
                SubjectName = subjectName,
            };

            await this.data.Types.AddAsync(type);
            await this.data.SaveChangesAsync();
        }

        public async Task<bool> EditTypeAsync(int id, string subjectName)
        {
            var currentType = this.data.Types.FirstOrDefault(x => x.Id == id);

            if (currentType == null)
            {
                return false;
            }

            currentType.SubjectName = subjectName;

            await this.data.SaveChangesAsync();

            return true;
        }

        public IEnumerable<TypeFormModelForAdmin> GetTypes()
        => this.data.Types.Select(x => new TypeFormModelForAdmin
        {
            Id = x.Id,
            SubjectName = x.SubjectName,
        });
    }
}
