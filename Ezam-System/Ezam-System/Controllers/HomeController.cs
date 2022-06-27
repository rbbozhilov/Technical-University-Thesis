using Ezam_System.Models;
using Ezam_System.Services.Posts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ezam_System.Controllers
{
    public class HomeController : Controller
    {

        private IPostService postService;

        public HomeController(IPostService postService)
        {
            this.postService = postService;
        }

        public IActionResult Index()
         => View(this.postService.GetAllPostsDetails());

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}