using System.ComponentModel.DataAnnotations;

namespace WebApiTodo.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
    }
}
