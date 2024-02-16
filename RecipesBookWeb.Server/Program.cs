
using Microsoft.EntityFrameworkCore;
using RecipesBook.Repositories;

namespace RecipesBookWeb.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<RecipeContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseAuthorization();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Api}/{action=Recipe}/{id?}");

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
