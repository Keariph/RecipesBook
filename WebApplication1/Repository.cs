using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebApplication1
{
    public class Repository : DbContext
    {
        public DbSet<Model> Models => Set<Model>();
        public Repository() => Database.EnsureCreated();
        //StreamWriter logStream = new StreamWriter("mylog.txt", false);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=models;Username=postgres;Password=1313");
            //optionsBuilder.LogTo(Console.WriteLine);
        }

        public void Create(Model model)
        {
            using(Repository repository = new Repository())
            {
                repository.Models.Add(model);
                repository.SaveChanges();
            }
        }

        public List<Model> ReadAll()
        {
            using(Repository repository = new Repository())
            {
                return repository.Models.ToList();
            }
        }

        public Model ReadOne(int id)
        {
            using (Repository repository = new Repository())
            {
                Model model = repository.Models.Find(id);
                return model;
            }
        }

        public void Update(Model model)
        {
            using(Repository repository = new Repository())
            {
                repository.Models.Update(model);
                repository.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using(Repository repository = new Repository())
            {
                Model model = repository.Models.Find(id);

                if (model != null)
                {
                    repository.Models.Remove(model); 
                    repository.SaveChanges();
                }
            }
        }
    }
}
