using Ezam_System.Controllers;
using Ezam_System.Services.Posts;
using Ezam_System.Tests.Mock;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Ezam_System.Tests.Controller
{
    public class HomeControllerTest
    {

        [Fact]
        public void TestingIndex_ShouldReturnViewResult()
        {

            //Arrange
            using var data = DatabaseMock.Instance;
            var postService = new PostService(data);
            var homeController = new HomeController(postService);

            //Act

            var result = homeController.Index();

            //Assert

            Assert.IsType<ViewResult>(result);

        }


    }
}
