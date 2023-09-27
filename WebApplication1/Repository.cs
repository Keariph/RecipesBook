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
            using(Repository rp = new Repository())
            {
                rp.Models.Add(model);
                rp.SaveChanges();
            }
        }

        public List<Model> ReadAll()
        {
            using(Repository rp = new Repository())
            {
                return rp.Models.ToList();
            }
        }

        public Model ReadOne(int id)
        {
            using (Repository rp = new Repository())
            {
                Model model = rp.Models.Find(id);
                return model;

            }
        }

        public void Update(Model model)
        {
            using(Repository rp = new Repository())
            {
                rp.Models.Update(model);
                rp.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using(Repository rp = new Repository())
            {
                Model model = rp.Models.Find(id);
                if (model != null)
                {
                    rp.Models.Remove(model); 
                    rp.SaveChanges();
                }
            }
        }
    }
}
