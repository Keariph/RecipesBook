using Microsoft.EntityFrameworkCore;
using RecipesBookWeb.Server.Models;

namespace RecipesBookWeb.Server.Repositories
{
    /// <summary>
    /// Represents a session with the database for managing review.
    /// </summary>
    /// <remarks>
    /// This class is a custom <see cref="DbContext"/> that includes a <see cref="DbSet{Review}"/> for managing <see cref="Review"/> entities.
    /// It is configured to use the specified database provider and connection string, which are passed through the <see cref="DbContextOptions{ReviewContext}"/> parameter.
    /// </remarks>
    public class ReviewContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReviewContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public ReviewContext(DbContextOptions<ReviewContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{Review}"/> that can be used to query and save instances of <see cref="Review"/>.
        /// </summary>
        public DbSet<Review> Reviews => Set<Review>();
    }
}
