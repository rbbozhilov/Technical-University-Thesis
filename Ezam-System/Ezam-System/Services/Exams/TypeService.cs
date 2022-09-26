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


        public void AddType(string subjectName)
        {
            var type = new Ezam_System.Data.Models.Exam.Type()
            {
                SubjectName = subjectName,
            };

            this.data.Types.Add(type);
            this.data.SaveChanges();
        }

        public bool EditType(int id, string subjectName)
        {
            var currentType = this.data.Types.FirstOrDefault(x => x.Id == id);

            if (currentType == null)
            {
                return false;
            }

            currentType.SubjectName = subjectName;

            this.data.SaveChanges();

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
