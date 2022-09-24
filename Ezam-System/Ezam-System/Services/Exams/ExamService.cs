using Ezam_System.Data;
using Ezam_System.Data.Models.Exam;
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

        public void AddExam(string hall, DateTime date, DateTime time, int typeId, int statusId)
        {
            var exam = new Exam()
            {
                Hall = hall,
                Date = date,
                Time = time,
                TypeId = typeId,
                StatusId = statusId
            };

            this.data.Exams.Add(exam);

            this.data.SaveChanges();
        }

        public bool DeleteExam(int id)
        {

            var currentExam = this.data.Exams.FirstOrDefault(x => x.Id == id);

            if (currentExam == null)
            {
                return false;
            }

            this.data.Exams.Remove(currentExam);
            this.data.SaveChanges();

            return true;
        }

        public bool EditExam(int id, string hall, DateTime date, DateTime time, int typeId, int statusId)
        {
            var currentExam = this.data.Exams.FirstOrDefault(x => x.Id == id);

            if (currentExam == null)
            {
                return false;
            }

            currentExam.Hall = hall;
            currentExam.Date = date;
            currentExam.Time = time;
            currentExam.TypeId = typeId;
            currentExam.StatusId = statusId;

            this.data.SaveChanges();

            return true;

        }

        public IEnumerable<StatusViewModel> GetAllStatuses()
         => this.data.Statuses
                      .Select(x => new StatusViewModel
                      {
                          Id = x.Id,
                          StatusName = x.StatusName
                      })
                      .ToList();

        public IEnumerable<TypeViewModel> GetAllTypes()
        => this.data.Types
                      .Select(x => new TypeViewModel
                      {
                          Id = x.Id,
                          SubjectName = x.SubjectName
                      })
                      .ToList();


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

        public bool isHaveStatus(int statusId)
        => this.data.Statuses.Any(x => x.Id == statusId);

        public bool IsHaveType(int typeId)
        => this.data.Types.Any(x => x.Id == typeId);

        public IEnumerable<string> Types()
        => this.data.Types.Select(x => x.SubjectName);

    }
}
