using Ezam_System.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Ezam_System.Tests.Controller
{
    public class BaseControllerTest
    {

        [Fact]
        public void TestingIndex_ShouldReturnViewResult()
        {

            //Arrange
            var baseController = new BaseController();

            //Act

            var result = baseController.Index();

            //Assert

            Assert.IsType<ViewResult>(result);

        }


    }
}
