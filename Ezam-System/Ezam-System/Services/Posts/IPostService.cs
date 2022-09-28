using Ezam_System.Models.Post;
using Ezam_System.Views.ViewModels.Post;

namespace Ezam_System.Services.Posts
{
    public interface IPostService
    {

        Task CreateAsync(
                  string fullname,
                  string message,
                  DateTime dateTime);


        Task<bool> EditAsync(
                  int id,
                  string fullname,
                  string message,
                  DateTime dateTime);

        Task<bool> DeleteAsync(int id);

        PostFormModel GetPostById(int id);

        IEnumerable<PostFormModelForAdmin> GetAllPostsForAdmin();

        IEnumerable<AllPostDetailsViewModel> GetAllPostsDetails();

    }
}
