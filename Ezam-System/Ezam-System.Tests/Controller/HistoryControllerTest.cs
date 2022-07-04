using Ezam_System.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Ezam_System.Tests.Controller
{
    public class HistoryControllerTest
    {

        [Fact]
        public void TestingIndex_ShouldReturnViewResult()
        {

            //Arrange
            var historyController = new HistoryController();

            //Act

            var result = historyController.Index();

            //Assert

            Assert.IsType<ViewResult>(result);

        }


    }
}
