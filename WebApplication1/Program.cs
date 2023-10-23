using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RecipesBook
{
    public class Program
    {       
        public static void Main(string[] args)
        {
            Repository repository = new Repository();
            var builder = WebApplication.CreateBuilder();
            //builder.Services.AddDbContext<Repository>(context => context.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));
            var app = builder.Build();
            Recipe recipe1 = repository.ReadOne();
            string json = JsonSerializer.Serialize(recipe1);
            app.MapGet("/", () => json);
            app.Run(async (context) =>
            {
                var path = context.Request.Path;
                var fullPath = $"html/{path}";
                var response = context.Response;
                response.ContentType = "text/html; charset=utf-8";              
                await response.WriteAsync(json);
            });

            app.Run();
        }
    }
}