using Microsoft.AspNetCore.Mvc;

namespace Ezam_System.Controllers
{
    public class BaseController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
