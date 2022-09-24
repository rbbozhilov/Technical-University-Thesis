using Ezam_System.Data;

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

        public bool DeleteType(int id)
        {
            var currentType = this.data.Types.FirstOrDefault(x => x.Id == id);

            if (currentType == null)
            {
                return false;
            }

            this.data.Types.Remove(currentType);
            this.data.SaveChanges();

            return true;
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
    }
}
