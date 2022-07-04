using Ezam_System.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Ezam_System.Tests.Controller
{
    public class PublicationControllerTest
    {

        [Fact]
        public void TestingIndex_ShouldReturnViewResult()
        {

            //Arrange
            var publicationController = new PublicationController();

            //Act

            var result = publicationController.Index();

            //Assert

            Assert.IsType<ViewResult>(result);

        }


    }
}
