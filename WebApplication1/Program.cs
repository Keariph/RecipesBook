using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class Program : DbContext
    {


        public static void Main(string[] args)
        {
            /*var builder = WebApplication.CreateBuilder();
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.Run();*/

            /*Model a = new Model(1, "A");
            Model b = new Model(2, "b");*/

            Repository rp = new Repository();
            var models = rp.Read();
            Console.WriteLine("Список объектов:");
            foreach (Model m in models)
            {
                Console.WriteLine($"{m.Id}.{m.Name}");
            }

        }
    }
}