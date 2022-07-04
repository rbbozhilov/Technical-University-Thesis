using Ezam_System.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ezam_System.Tests.Models
{
    public class PostFormModelForAdminTest
    {


        [Fact]
        public void CreatingInstance_ShouldBeCorrect()
        {

            //Arrange
            var postFormModel = new PostFormModelForAdmin();
            var expectedId = 1;
            var expectedFullName = "test";



            //Act

            postFormModel.Id = 1;
            postFormModel.FullName = "test";


            //Assert

            Assert.Equal(expectedId, postFormModel.Id);
            Assert.Equal(expectedFullName, postFormModel.FullName);

        }

    }
}
