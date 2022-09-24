using Ezam_System.Data;
using Ezam_System.Views.ViewModels.Exam;

namespace Ezam_System.Services.Exams
{
    public class ExamService : IExamService
    {

        private EzamDbContext data;

        public ExamService(EzamDbContext data)
        {
            this.data = data;
        }

        public IEnumerable<InformationViewModel> GetInformation(string type)
        => data.Exams
                 .Select(x => new InformationViewModel()
                 {
                     SubjectName = x.Type.SubjectName,
                     Hall = x.Hall,
                     Status = x.Status.StatusName,
                     Date = x.Date,
                     Time = x.Time
                 })
                 .Where(x => x.SubjectName == type)
                 .ToList();



        public IEnumerable<string> Types()
        => this.data.Types.Select(x => x.SubjectName);

    }
}
