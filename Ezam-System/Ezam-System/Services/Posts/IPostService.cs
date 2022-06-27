using Ezam_System.Models.Post;
using Ezam_System.Views.ViewModels.Post;

namespace Ezam_System.Services.Posts
{
    public interface IPostService
    {

        void Create(
                  string fullname,
                  string message,
                  DateTime dateTime);


        bool Edit(
                  int id,
                  string fullname,
                  string message,
                  DateTime dateTime);

        bool Delete(int id);

        PostFormModel GetPostById(int id);

        IEnumerable<PostFormModelForAdmin> GetAllPostsForAdmin();

        IEnumerable<AllPostDetailsViewModel> GetAllPostsDetails();

    }
}
