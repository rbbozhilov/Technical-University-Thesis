using Ezam_System.Data;
using Ezam_System.Data.Models;
using Ezam_System.Models.Post;
using Ezam_System.Views.ViewModels.Post;

namespace Ezam_System.Services.Posts
{
    public class PostService : IPostService
    {

        private EzamDbContext data;

        public PostService(EzamDbContext data)
        {
            this.data = data;
        }


        public void Create(string fullname, string message, DateTime dateTime)
        {
            var newPost = new Post()
            {
                FullName = fullname,
                Message = message,
                DateTime = dateTime
            };

            this.data.Posts.Add(newPost);

            this.data.SaveChanges();
        }

        public bool Delete(int id)
        {
            var currentPost = this.data.Posts
                                       .Where(p => p.Id == id && p.IsDeleted == false)
                                       .FirstOrDefault();

            if (currentPost == null)
            {
                return false;
            }


            currentPost.IsDeleted = true;

            this.data.SaveChanges();

            return true;
        }

        public bool Edit(int id, string fullname, string message, DateTime dateTime)
        {
            var currentPost = this.data.Posts
                                   .Where(p => p.Id == id && p.IsDeleted == false)
                                   .FirstOrDefault();


            if (currentPost == null)
            {
                return false;
            }

            currentPost.FullName = fullname;
            currentPost.Message = message;
            currentPost.DateTime = dateTime;

            this.data.SaveChanges();

            return true;
        }

        public IEnumerable<AllPostDetailsViewModel> GetAllPostsDetails()
        => this.data.Posts
                    .Where(p => p.IsDeleted == false)
                    .Select(p => new AllPostDetailsViewModel()
                    {
                        FullName = p.FullName,
                        Message = p.Message,
                        DateTime = p.DateTime
                    })
                    .ToList();

        public IEnumerable<PostFormModelForAdmin> GetAllPostsForAdmin()
         => this.data.Posts
                    .Where(p => p.IsDeleted == false)
                    .Select(p => new PostFormModelForAdmin()
                    {
                        Id = p.Id,
                        FullName = p.FullName,
                        Message = p.Message
                    })
                    .ToList();

        public PostFormModel GetPostById(int id)
        => this.data.Posts
                     .Where(p => p.Id == id && p.IsDeleted == false)
                     .Select(p => new PostFormModel()
                     {
                         FullName = p.FullName,
                         Message = p.Message,
                         DateTime = p.DateTime
                     })
                     .FirstOrDefault();
    }
}
