using Ezam_System.Models.Staff;
using Microsoft.AspNetCore.Mvc;

namespace Ezam_System.Controllers
{
    public class AdminPanelController : Controller
    {

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

            //Adding service for staff add
            //this.recipeService.Create(
            //                          recipeModel.Name,
            //                          recipeModel.Description,
            //                          recipeModel.ImageUrl);


            return RedirectToAction("Successfull");
        }


        public IActionResult SuccessFull()
            => View();




    }
}
