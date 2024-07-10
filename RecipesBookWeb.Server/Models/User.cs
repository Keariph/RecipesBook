using System.ComponentModel.DataAnnotations;

namespace RecipesBookWeb.Server.Models
{
    /// <summary>
    /// Represents a user with details such as email, favorite recipes, and owned recipes.
    /// </summary>
    /// <remarks>
    /// This class is used to model a user in authorization and authentication. It includes properties for the user's nickname, email, and favorite recipes.
    /// </remarks>
    public class User
    {
        /// <summary>
        /// Initializes a new instance <see cref="User"/> class.
        /// </summary>
        /// <param name="id">The unique identifier for the user.</param>
        /// <param name="nickname">The nickname for the user.</param>
        /// <param name="email">The email of the user.</param>
        /// <param name="favoritesRecipes">The favorite recipes of the user.</param>
        /// <param name="ownedRecipes">The recipes are written by the user.</param>
        public User(string id, string nickname, string email, List<string> favoritesRecipes, List<string> ownedRecipes)
        {
            Id = id;
            Nickname = nickname;
            Email = email;
            FavoritesRecipes = favoritesRecipes;
            OwnedRecipes = ownedRecipes;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the nickname for the user.
        /// </summary>
        /// <remarks>
        /// The nickname must be a string with a maximum length of 20 characters and cannot contain any of the following invalid characters: @#$%*.
        /// </remarks>
        [StringLength(20)]
        [InvalidChars("#$%^&*()+=")]
        public string Nickname { get; set; }

        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        /// <remarks>
        /// The email must correspond to the email format: adress@email.com
        /// </remarks>
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the favorite recipes of the user.
        /// </summary>
        public List<string> FavoritesRecipes { get; set; }

        /// <summary>
        /// Gets or sets the recipes are written by the user.
        /// </summary>
        public List<string> OwnedRecipes { get; set; }
    }
}
