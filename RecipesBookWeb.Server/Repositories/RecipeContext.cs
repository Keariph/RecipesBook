using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RecipesBook.Models;
using System.Collections.Generic;

namespace RecipesBook.Repositories
{
    /// <summary>
    /// Represents a session with the database for managing recipes.
    /// </summary>
    /// <remarks>
    /// This class is a custom <see cref="DbContext"/> that includes a <see cref="DbSet{Recipe}"/> for managing <see cref="Recipe"/> entities.
    /// It is configured to use the specified database provider and connection string, which are passed through the <see cref="DbContextOptions{RecipeContext}"/> parameter.
    /// </remarks>
    public class RecipeContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public RecipeContext(DbContextOptions<RecipeContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{Recipe}"/> that can be used to query and save instances of <see cref="Recipe"/>.
        /// </summary>
        public DbSet<Recipe> Recipes => Set<Recipe>();
    }
}
