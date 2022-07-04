using Ezam_System.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Ezam_System.Tests.Controller
{
    public class StudyControllerTest
    {

        [Fact]
        public void TestingIndex_ShouldReturnViewResult()
        {

            //Arrange
            var studyController = new StudyController();

            //Act
            var result = studyController.Index();

            //Assert
            Assert.IsType<ViewResult>(result);

        }

    }
}
