using Ezam_System.Models.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ezam_System.Tests.Models
{
    public class StaffFormModelForAdminTest
    {

        [Fact]
        public void TestingCreateD()
        {

            //Arrange
            var staffFormModel = new StaffFormModelForAdmin();
            var expectedId = 1;
            var expectedFullName = "test";



            //Act

            staffFormModel.Id = 1;
            staffFormModel.FullName = "test";


            //Assert

            Assert.Equal(expectedId,staffFormModel.Id);
            Assert.Equal(expectedFullName,staffFormModel.FullName);

        }

    }
}
