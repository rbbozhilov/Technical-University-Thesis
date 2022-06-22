using Ezam_System.Services.Staffs;
using Microsoft.AspNetCore.Mvc;

namespace Ezam_System.Controllers
{
    public class StaffController : Controller
    {

        private IStaffService staffService;

        public StaffController(IStaffService staffService)
        {
            this.staffService = staffService;
        }

        public IActionResult Index()
        => View(this.staffService.GetAllStaffDetails());

    }
}
