using WebApiTodo.Data;
using WebApiTodo.Models;
using WebApiTodo.Services.Intefaces;

namespace WebApiTodo.Services
{
    public class TodoService : IPostService
    {
        private AppDbContext _context;
        public TodoService(AppDbContext context)
        {
            _context = context;
        }
        public PostModel Create(PostModel model)
        {
            _context.Posts.Add(model);
            try
            {
                _context.SaveChanges(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return model;
        }
        public PostModel Update(PostModel model)
        {
            var modelToUpdate = _context.Posts.FirstOrDefault(p => p.Id == model.Id);
            if (modelToUpdate == null)
                return null;
            modelToUpdate.Header = model.Header;
            modelToUpdate.Description = model.Description;
            _context.SaveChanges();
            return modelToUpdate;
        }

        public void Delete(int id)
        {
            var modelTODelete = _context.Posts.FirstOrDefault(p => p.Id == id);
            if (modelTODelete != null)
            {
                _context.Posts.Remove(modelTODelete);
                _context.SaveChanges();
            }
        }
        public PostModel Get(int id)
        {
            var model = _context.Posts.FirstOrDefault(p => p.Id == id);
            if (model != null)
                return model;
            else return null;
        }

        public List<PostModel> Get()
        {
            var posts = _context.Posts.ToList();
            if (posts != null)
                return posts;
            else return null;
        }
    }
}