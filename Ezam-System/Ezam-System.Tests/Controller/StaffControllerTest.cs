using Ezam_System.Controllers;
using Ezam_System.Services.Staffs;
using Ezam_System.Tests.Mock;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Ezam_System.Tests.Controller
{
    public class StaffControllerTest
    {

        [Fact]
        public void TestingIndex_ShouldReturnViewResult()
        {

            //Arrange
            using var data = DatabaseMock.Instance;
            var staffService = new StaffService(data);
            var staffController = new StaffController(staffService);

            //Act

            var result = staffController.Index();

            //Assert

            Assert.IsType<ViewResult>(result);

        }


    }
}
