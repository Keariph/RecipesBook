using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApplication1
{
    public class Repository : DbContext
    {
        public DbSet<Model> Models => Set<Model>();
        public Repository() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=models;Username=postgres;Password=1313");
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }

        public void Create(Model model)
        {
            using(Repository rp = new Repository())
            {
                rp.Models.Add(model);
                rp.SaveChanges();
            }
        }

        public List<Model> Read()
        {
            using(Repository rp = new Repository())
            {
                return rp.Models.ToList();
            }
        }


    }
}
