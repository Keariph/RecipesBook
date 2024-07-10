using Microsoft.EntityFrameworkCore;
using RecipesBookWeb.Server.Models;

namespace RecipesBookWeb.Server.Repositories
{

    /// <summary>
    /// Represents a session with the database for managing users.
    /// </summary>
    /// <remarks>
    /// This class is a custom <see cref="DbContext"/> that includes a <see cref="DbSet{User}"/> for managing <see cref="User"/> entities.
    /// It is configured to use the specified database provider and connection string, which are passed through the <see cref="DbContextOptions{UserContext}"/> parameter.
    /// </remarks>
    public class UserContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{User}"/> that can be used to query and save instances of <see cref="User"/>.
        /// </summary>
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Users");
        }
    }
}
