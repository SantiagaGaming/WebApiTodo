using WebApiTodo.Models;

namespace WebApiTodo.Services.Intefaces
{
    public interface IPostService
    {
        PostModel Create(PostModel model);
        PostModel Update(PostModel model);
        PostModel Get(int id);
        List<PostModel> Get();
        void Delete(int id);
    }
}
