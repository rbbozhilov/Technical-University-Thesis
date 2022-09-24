using Ezam_System.Services.Exams;
using Ezam_System.Views.ViewModels.Exam;
using Microsoft.AspNetCore.Mvc;

namespace Ezam_System.Controllers
{
    public class ExamController : Controller
    {

        private IExamService examService;

        public ExamController(IExamService examService)
        {
            this.examService = examService;
        }

        public IActionResult Index([FromQuery]ExamViewModel query)
        {

            var examModel = new ExamViewModel()
            {
                Types = this.examService.Types()
            };

            if(!string.IsNullOrEmpty(query.Type) &&
               !string.IsNullOrWhiteSpace(query.Type))
            {
                var information = this.examService.GetInformation(query.Type);

                return View("Result",information);
            }

            return View(examModel);
        }


    }
}
