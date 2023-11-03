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
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            var app = builder.Build();
            app.MapControllers();
            app.Run();
        }
    }
}