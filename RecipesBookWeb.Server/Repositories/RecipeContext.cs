using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RecipesBook.Models;
using System.Collections.Generic;

namespace RecipesBook.Repositories
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes => Set<Recipe>();
    }
}
