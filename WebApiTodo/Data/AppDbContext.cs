using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApiTodo.Models;

namespace WebApiTodo.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<PostModel> Posts { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
