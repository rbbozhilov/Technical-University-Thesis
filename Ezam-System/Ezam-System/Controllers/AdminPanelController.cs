using Ezam_System.Models.Dissertation;
using Ezam_System.Models.Exam;
using Ezam_System.Models.Post;
using Ezam_System.Models.Staff;
using Ezam_System.Services.Dissertations;
using Ezam_System.Services.Exams;
using Ezam_System.Services.Posts;
using Ezam_System.Services.Staffs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ezam_System.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminPanelController : Controller
    {

        private readonly IStaffService staffService;
        private readonly IDissertationService dissertationService;
        private readonly IPostService postService;
        private readonly IExamService examService;
        private readonly ITypeService typeService;


        public AdminPanelController(
                                    IStaffService staffService,
                                    IDissertationService dissertationService,
                                    IPostService postService,
                                    IExamService examService,
                                    ITypeService typeService)
        {
            this.staffService = staffService;
            this.dissertationService = dissertationService;
            this.postService = postService;
            this.examService = examService;
            this.typeService = typeService;
        }


        public IActionResult Index()
        => this.View();


        public IActionResult AddType()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddType(TypeFormModel typeModel)
        {
            if (!ModelState.IsValid)
            {
                return View(typeModel);
            }

            await this.typeService.AddTypeAsync(typeModel.SubjectName);

            return View("Index");
        }

        public IActionResult EditType()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditType(TypeFormModel typeModel, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(typeModel);
            }

            bool isEditted = await this.typeService.EditTypeAsync(id, typeModel.SubjectName);

            if (!isEditted)
            {
                return BadRequest();
            }

            return View("Index");
        }

        public IActionResult ShowType(IEnumerable<TypeFormModelForAdmin> types)
        {
            types = this.typeService.GetTypes();

            return this.View(types);
        }

        public IActionResult AddExam()
        {
            return this.View(new ExamFormModel()
            {
                Type = this.examService.GetAllTypes(),
                Status = this.examService.GetAllStatuses()
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddExam(ExamFormModel examFormModel)
        {
            if (!this.examService.IsHaveType(examFormModel.TypeId))
            {
                this.ModelState.AddModelError(nameof(examFormModel.TypeId), "Don't make some hack tries!");
            }

            if (!this.examService.isHaveStatus(examFormModel.StatusId))
            {
                this.ModelState.AddModelError(nameof(examFormModel.StatusId), "Don't make some hack tries!");
            }


            if (!ModelState.IsValid)
            {
                examFormModel.Type = this.examService.GetAllTypes();
                examFormModel.Status = this.examService.GetAllStatuses();

                return View(examFormModel);
            }

            await this.examService.AddExamAsync(
                                     examFormModel.Hall,
                                     examFormModel.Date,
                                     examFormModel.Time,
                                     examFormModel.TypeId,
                                     examFormModel.StatusId);

            return View("Index");
        }

        public IActionResult EditExam(int id)
        {

            var currentExam = this.examService.GetExamById(id);

            if (currentExam == null)
            {
                return BadRequest();
            }

            return this.View(new ExamEditFormModel
            {
                Status = this.examService.GetAllStatuses()
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditExam(ExamEditFormModel editFormModel, int id)
        {

            if (!ModelState.IsValid)
            {
                editFormModel.Status = this.examService.GetAllStatuses();

                return this.View(editFormModel);
            }

            bool isEditted = await this.examService.EditExamAsync(
                                        id,
                                        editFormModel.Hall,
                                        editFormModel.Date,
                                        editFormModel.Time,
                                        editFormModel.StatusId);

            if (!isEditted)
            {
                return BadRequest();
            }

            return View("Index");

        }

        public async Task<IActionResult> DeleteExam(int id)
        {

            bool isDeleted = await this.examService.DeleteExamAsync(id);

            if (!isDeleted)
            {
                return BadRequest();
            }

            return View("Index");
        }

        public IActionResult ShowExam(IEnumerable<ExamFormModelForAdmin> examFormModel)
        {
            examFormModel = this.examService.GetExamsForAdminView();

            return View(examFormModel);
        }

        public IActionResult AddStaff()
            => View();

        [HttpPost]
        public async Task<IActionResult> AddStaff(StaffFormModel staffFormModel)
        {

            if (!ModelState.IsValid)
            {
                return View(staffFormModel);
            }

            await this.staffService.CreateAsync(
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
        public async Task<IActionResult> EditStaff(StaffFormModel staffFormModel, int id)
        {

            if (!ModelState.IsValid)
            {
                return View(staffFormModel);
            }

            bool isEditted = await this.staffService.EditAsync(
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


        public async Task<IActionResult> DeleteStaff(int id)
        {

            bool isDeleted = await this.staffService.DeleteAsync(id);

            if (!isDeleted)
            {
                return BadRequest();
            }

            return View("Successfull");
        }


        public IActionResult AddDissertation()
           => View();

        [HttpPost]
        public async Task<IActionResult> AddDissertation(DissertationFormModel dissertationFormModel)
        {

            if (!ModelState.IsValid)
            {
                return View(dissertationFormModel);
            }


            await this.dissertationService.CreateAsync(
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
        public async Task<IActionResult> EditDissertation(DissertationFormModel dissertationFormModel, int id)
        {

            if (!ModelState.IsValid)
            {
                return View(dissertationFormModel);
            }

            bool isEditted = await this.dissertationService.EditAsync(
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


        public async Task<IActionResult> DeleteDissertation(int id)
        {

            var isDeleted = await this.dissertationService.DeleteAsync(id);

            if (!isDeleted)
            {
                return BadRequest();
            }

            return View("Successfull");
        }


        public IActionResult AddPost()
          => View();

        [HttpPost]
        public async Task<IActionResult> AddPost(PostFormModel postFormModel)
        {

            if (!ModelState.IsValid)
            {
                return View(postFormModel);
            }


            await this.postService.CreateAsync(
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
        public async Task<IActionResult> EditPost(PostFormModel postFormModel, int id)
        {

            if (!ModelState.IsValid)
            {
                return View(postFormModel);
            }

            bool isEditted = await this.postService.EditAsync(
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


        public async Task<IActionResult> DeletePost(int id)
        {

            bool isDeleted = await this.postService.DeleteAsync(id);

            if (!isDeleted)
            {
                return BadRequest();
            }

            return View("Successfull");
        }



        public IActionResult SuccessFull()
            => View();

    }
}
