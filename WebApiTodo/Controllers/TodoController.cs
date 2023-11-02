using Microsoft.AspNetCore.Mvc;
using WebApiTodo.Models;
using WebApiTodo.Services.Intefaces;

namespace WebApiTodo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private IPostService _postService;
        public TodoController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpPost]
        public PostModel Create(PostModel model)
        {
            Console.WriteLine(model.Header);
            return _postService.Create(model);
        }
        //[HttpPost]
        //public PostModel Create(dynamic value)
        //{
        //    Console.WriteLine("in post model");
        //    Console.WriteLine(value);
        //    return null;
        //}


        [HttpPatch]
        public PostModel Update(PostModel model)
        {
            return _postService.Update(model);
        }
        [HttpGet("{id}")]
        public PostModel Get(int id)
        {
            return _postService.Get(id);
        }
        [HttpGet]
        public IEnumerable<PostModel> GetAll()
        {
            return _postService.Get();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _postService.Delete(id);
            return Ok();
        }
    }
}