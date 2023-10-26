using Microsoft.EntityFrameworkCore;
using WebApiTodo.Services.Intefaces;
using WebApiTodo.Services;
using WebApiTodo.Data;

namespace WebApiTodo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddTransient<IPostService, TodoService>();
            builder.Services.AddCors();
            var app = builder.Build();
            app.UseCors( builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
            app.UseHttpsRedirection();
            app.MapControllerRoute(
name: "default",
pattern: "{controller}/{action=Index}/{id?}");
            app.MapControllers();
            app.Run();
        }
    }
}