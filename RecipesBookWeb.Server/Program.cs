
using Microsoft.EntityFrameworkCore;
using RecipesBook.Models;
using RecipesBook.Repositories;
using System.Text.Json;

namespace RecipesBookWeb.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddDbContext<RecipeContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));
            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Api}/{action=Recipe}/{id?}");

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
