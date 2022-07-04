using Ezam_System.Models.Dissertation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ezam_System.Tests.Models
{
    public class DissertationFormModelForAdminTest
    {

        [Fact]
        public void CreatingInstance_ShouldBeCorrect()
        {

            //Arrange
            var dissertation = new DissertationFormModelForAdmin();
            var expectedId = 1;
            var expectedFullName = "test";



            //Act

            dissertation.Id = 1;
            dissertation.FullName = "test";


            //Assert

            Assert.Equal(expectedId, dissertation.Id);
            Assert.Equal(expectedFullName, dissertation.FullName);

        }


    }
}
