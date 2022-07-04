using Ezam_System.Data.Models;
using Ezam_System.Services.Posts;
using Ezam_System.Tests.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ezam_System.Tests.Services
{
    public class PostServiceTest
    {

        [Fact]
        public void AddPost_ShouldReturnTrue()
        {

            //Arrange

            using var data = DatabaseMock.Instance;
            var postService = new PostService(data);
            var id = 1;
            var message = "hello";
            var fullName = "name";
            var date = DateTime.Now;

            //Act

            postService.Create(
                               fullName,
                               message,
                               date);


            var post = data.Posts
                           .Where(p => p.FullName == fullName)
                           .FirstOrDefault();


            //Assert

            Assert.Equal(id, post.Id);
            Assert.Equal(fullName, post.FullName);
            Assert.Equal(message, post.Message);
            Assert.Equal(date, post.DateTime);

        }

        [Fact]
        public void EditPost_ShouldReturnTrue()
        {

            //Arrange

            using var data = DatabaseMock.Instance;
            var post = new Post()
            {
                Id = 1,
                FullName = "name",
                Message = "hello",
                DateTime = DateTime.Now
            };

            var postService = new PostService(data);


            //Act

            data.Posts.Add(post);
            data.SaveChanges();

            var result = postService.Edit(1,"name1","message1",DateTime.Now);

            //Assert

            Assert.True(result);
            Assert.NotEqual("name", post.FullName);
            Assert.NotEqual("snamemessage", post.Message);

        }

        [Fact]
        public void DeletePost_ShouldReturnFalse()
        {

            //Arrange

            using var data = DatabaseMock.Instance;
            var postService = new PostService(data);


            //Assert

            Assert.False(postService.Delete(1));

        }


        [Fact]
        public void DeletePost_ShouldBeSuccess()
        {

            //Arrange

            using var data = DatabaseMock.Instance;
            var postService = new PostService(data);

            //Act

            data.Posts.Add(new Post() { Id = 1, FullName = "g", Message = "m", DateTime = DateTime.Now });
            data.SaveChanges();

            //Assert

            Assert.True(postService.Delete(1));
        }


    }
}
