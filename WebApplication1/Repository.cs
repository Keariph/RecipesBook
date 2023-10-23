using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RecipesBook
{
    public class Repository : DbContext
    {
        public DbSet<Recipe> Recipes => Set<Recipe>();
        public Repository() => Database.EnsureCreated();
        //StreamWriter logStream = new StreamWriter("mylog.txt", false);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=recipes;Username=postgres;Password=1313");
            //optionsBuilder.LogTo(Console.WriteLine);
        }

        public void Create(Recipe model)
        {
            using(Repository repository = new Repository())
            {
                repository.Recipes.Add(model);
                repository.SaveChanges();
            }
        }

        public List<Recipe> ReadAll()
        {
            using(Repository repository = new Repository())
            {
                return repository.Recipes.ToList();
            }
        }

        public Recipe ReadOne(/*string id*/)
        {
            using (Repository repository = new Repository())
            {
                //Recipe model = repository.Recipes.Find(id);
                Recipe model = repository.Recipes.First();
                return model;
            }
        }

        public void Update(Recipe model)
        {
            using(Repository repository = new Repository())
            {
                repository.Recipes.Update(model);
                repository.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            using(Repository repository = new Repository())
            {
                Recipe model = repository.Recipes.Find(id);

                if (model != null)
                {
                    repository.Recipes.Remove(model); 
                    repository.SaveChanges();
                }
            }
        }
    }
}
