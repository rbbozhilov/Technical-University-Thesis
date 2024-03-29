﻿using Ezam_System.Data.Models;
using Ezam_System.Services.Dissertations;
using Ezam_System.Tests.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ezam_System.Tests.Services
{
    public class DissertationServiceTest
    {

        [Fact]
        public async Task AddDissertation_ShouldReturnTrue()
        {

            //Arrange
            using var data = DatabaseMock.Instance;
            var dissertationService = new DissertationService(data);
            var id = 1;
            var dissertationNumber = 0884444;
            var fullName = "name";
            var supervisor = "supervisor";

            //Act
            await dissertationService.CreateAsync(
                                        fullName,
                                        dissertationNumber,
                                        supervisor);


            var dissertation = data.Dissertations
                                 .Where(d => d.Supervisor == supervisor)
                                 .FirstOrDefault();
            //Assert
            Assert.Equal(id, dissertation.Id);
            Assert.Equal(dissertationNumber, dissertation.Number);
            Assert.Equal(supervisor, dissertation.Supervisor);

        }

        [Fact]
        public async Task EditDissertation_ShouldReturnTrue()
        {

            //Arrange
            using var data = DatabaseMock.Instance;
            var dissertation = new Dissertation()
            {
                Id = 1,
                FullName = "name",
                Supervisor = "sname",
                Number = 2344
            };
            var dissertationService = new DissertationService(data);
            //Act
            data.Dissertations.Add(dissertation);
            data.SaveChanges();

            var result = await dissertationService.EditAsync(1, "name2", 23444, "sname3");

            //Assert
            Assert.True(result);
            Assert.NotEqual("name", dissertation.FullName);
            Assert.NotEqual("sname", dissertation.Supervisor);
            Assert.NotEqual(2344, dissertation.Number);
        }

        [Fact]
        public async Task DeleteDissertation_ShouldReturnFalse()
        {

            //Arrange

            using var data = DatabaseMock.Instance;
            var dissertationService = new DissertationService(data);


            //Assert

            Assert.False(await dissertationService.DeleteAsync(1));

        }


        [Fact]
        public async Task DeleteDissertation_ShouldBeSuccess()
        {

            //Arrange

            using var data = DatabaseMock.Instance;
            var dissertationService = new DissertationService(data);

            //Act

            data.Dissertations.Add(new Dissertation()
            {
                Id = 1,
                FullName = "g",
                Supervisor = "m",
                Number = 1233
            });
            data.SaveChanges();

            //Assert

            Assert.True(await dissertationService.DeleteAsync(1));
        }
    }
}
