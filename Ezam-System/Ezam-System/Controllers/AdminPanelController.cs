using Ezam_System.Models.Dissertation;
using Ezam_System.Models.Post;
using Ezam_System.Models.Staff;
using Ezam_System.Services.Dissertations;
using Ezam_System.Services.Posts;
using Ezam_System.Services.Staffs;
using Microsoft.AspNetCore.Mvc;

namespace Ezam_System.Controllers
{
    public class AdminPanelController : Controller
    {

        private readonly IStaffService staffService;
        private readonly IDissertationService dissertationService;
        private readonly IPostService postService;


        public AdminPanelController(
                                    IStaffService staffService,
                                    IDissertationService dissertationService,
                                    IPostService postService)
        {
            this.staffService = staffService;
            this.dissertationService = dissertationService;
            this.postService = postService;
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


        public IActionResult AddDissertation()
           => View();

        [HttpPost]
        public IActionResult AddDissertation(DissertationFormModel dissertationFormModel)
        {

            if (!ModelState.IsValid)
            {
                return View(dissertationFormModel);
            }


            this.dissertationService.Create(
                                            dissertationFormModel.FullName,
                                            dissertationFormModel.Number,
                                            dissertationFormModel.Supervisor);


            return RedirectToAction("Successfull");
        }

        public IActionResult EditDissertation(int id)
        {
            var currentDissertation = this.dissertationService.GetDissertationById(id);

            if (currentDissertation == null)
            {
                return BadRequest();
            }


            return View(new DissertationFormModel()
            {
                FullName = currentDissertation.FullName,
                Number = currentDissertation.Number,
                Supervisor = currentDissertation.Supervisor
            });
        }

        [HttpPost]
        public IActionResult EditDissertation(DissertationFormModel dissertationFormModel, int id)
        {

            if (!ModelState.IsValid)
            {
                return View(dissertationFormModel);
            }

            bool isEditted = this.dissertationService.Edit(
                                                    id,
                                                    dissertationFormModel.FullName,
                                                    dissertationFormModel.Number,
                                                    dissertationFormModel.Supervisor);

            if (!isEditted)
            {
                return BadRequest();
            }


            return RedirectToAction("Successfull");

        }

        public IActionResult ShowDissertation(IEnumerable<DissertationFormModelForAdmin> dissertationFormModel)
        {
            dissertationFormModel = this.dissertationService.GetAllDissertationsForAdmin();

            return View(dissertationFormModel);
        }


        public IActionResult DeleteDissertation(int id)
        {

            if (!this.dissertationService.Delete(id))
            {
                return BadRequest();
            }

            return View("Successfull");
        }


        public IActionResult AddPost()
          => View();

        [HttpPost]
        public IActionResult AddPost(PostFormModel postFormModel)
        {

            if (!ModelState.IsValid)
            {
                return View(postFormModel);
            }


            this.postService.Create(
                                     postFormModel.FullName,
                                     postFormModel.Message,
                                     postFormModel.DateTime);


            return RedirectToAction("Successfull");
        }

        public IActionResult EditPost(int id)
        {
            var currentPost = this.postService.GetPostById(id);

            if (currentPost == null)
            {
                return BadRequest();
            }


            return View(new PostFormModel()
            {
                FullName = currentPost.FullName,
                Message = currentPost.Message,
                DateTime = currentPost.DateTime
            });
        }

        [HttpPost]
        public IActionResult EditPost(PostFormModel postFormModel, int id)
        {

            if (!ModelState.IsValid)
            {
                return View(postFormModel);
            }

            bool isEditted = this.postService.Edit(
                                                    id,
                                                    postFormModel.FullName,
                                                    postFormModel.Message,
                                                    postFormModel.DateTime);

            if (!isEditted)
            {
                return BadRequest();
            }


            return RedirectToAction("Successfull");

        }

        public IActionResult ShowPost(IEnumerable<PostFormModelForAdmin> postModel)
        {
            postModel = this.postService.GetAllPostsForAdmin();

            return View(postModel);
        }


        public IActionResult DeletePost(int id)
        {

            if (!this.postService.Delete(id))
            {
                return BadRequest();
            }

            return View("Successfull");
        }



        public IActionResult SuccessFull()
            => View();

    }
}
