using Ezam_System.Models.Staff;
using Ezam_System.Services.Staffs;
using Microsoft.AspNetCore.Mvc;

namespace Ezam_System.Controllers
{
    public class AdminPanelController : Controller
    {

        private readonly IStaffService staffService;

        public AdminPanelController(IStaffService staffService)
        {
            this.staffService = staffService;
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult AddStaff()
            => View();

        [HttpPost]
        public IActionResult AddStaff(StaffFormModel staffFormModel)
        {

            if (!ModelState.IsValid)
            {
                return View(staffFormModel);
            }


            this.staffService.Create(
                                     staffFormModel.FullName,
                                     staffFormModel.Position,
                                     staffFormModel.Email,
                                     staffFormModel.PhoneNumber,
                                     staffFormModel.ImageUrl,
                                     staffFormModel.Office);


            return RedirectToAction("Successfull");
        }

        public IActionResult EditStaff(int id)
        {
            var currentStaff = this.staffService.GetStaffById(id);

            if (currentStaff == null)
            {
                return BadRequest();
            }


            return View(new StaffFormModel()
            {
                FullName = currentStaff.FullName,
                Position = currentStaff.Position,
                Email = currentStaff.Email,
                PhoneNumber = currentStaff.PhoneNumber,
                ImageUrl = currentStaff.ImageUrl,
                Office = currentStaff.Office
            });
        }

        [HttpPost]
        public IActionResult EditStaff(StaffFormModel staffFormModel, int id)
        {

            if (!ModelState.IsValid)
            {
                return View(staffFormModel);
            }

            bool isEditted = this.staffService.Edit(
                                                    id,
                                                    staffFormModel.FullName,
                                                    staffFormModel.Position,
                                                    staffFormModel.Email,
                                                    staffFormModel.PhoneNumber,
                                                    staffFormModel.ImageUrl,
                                                    staffFormModel.Office);

            if (!isEditted)
            {
                return BadRequest();
            }


            return RedirectToAction("Successfull");

        }

        public IActionResult ShowStaff(IEnumerable<StaffFormModelForAdmin> staffModel)
        {
            staffModel = this.staffService.GetAllStaffForAdmin();

            return View(staffModel);
        }


        public IActionResult DeleteStaff(int id)
        {

            if (!this.staffService.Delete(id))
            {
                return BadRequest();
            }

            return View("Successfull");
        }


        public IActionResult SuccessFull()
            => View();

    }
}
