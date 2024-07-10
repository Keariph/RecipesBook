using Microsoft.EntityFrameworkCore;
using RecipesBook.Server.Repositories;
using RecipesBookWeb.Server.Repositories;
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
            builder.Services.AddDbContext<UserContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));
            builder.Services.AddSwaggerGen();
            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Api}/{action=Recipe}/{id?}");

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
