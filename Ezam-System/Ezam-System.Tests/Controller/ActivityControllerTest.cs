using Ezam_System.Controllers;
using Ezam_System.Services.Dissertations;
using Ezam_System.Tests.Mock;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Ezam_System.Tests.Controller
{
    public class ActivityControllerTest
    {

        [Fact]
        public void TestingScientific_ShouldReturnViewResult()
        {

            //Arrange
            using var data = DatabaseMock.Instance;
            var dissertationService = new DissertationService(data);
            var activityController = new ActivityController(dissertationService);

            //Act

            var result = activityController.Scientific();

            //Assert

            Assert.IsType<ViewResult>(result);

        }

        [Fact]
        public void TestingDissertation_ShouldReturnViewResult()
        {

            //Arrange
            using var data = DatabaseMock.Instance;
            var dissertationService = new DissertationService(data);
            var activityController = new ActivityController(dissertationService);

            //Act

            var result = activityController.Dissertation();

            //Assert

            Assert.IsType<ViewResult>(result);

        }



    }
}
