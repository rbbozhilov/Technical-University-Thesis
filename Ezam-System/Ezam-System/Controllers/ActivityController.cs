using Ezam_System.Services.Dissertations;
using Microsoft.AspNetCore.Mvc;

namespace Ezam_System.Controllers
{
    public class ActivityController : Controller
    {

        private IDissertationService dissertationService;

        public ActivityController(IDissertationService dissertationService)
        {
            this.dissertationService = dissertationService;
        }


        public IActionResult Scientific()
        {
            return View();
        }

        public IActionResult Dissertation()
        => View(this.dissertationService.GetAllDissertationsDetails());
    }
}
