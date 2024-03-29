using Microsoft.EntityFrameworkCore;
using RecipesBookWeb.Server.Models;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace RecipesBook.Models
{
    /// <summary>
    /// Represents a recipe with details such as ingredients, instructions, and preparation time.
    /// </summary>
    /// <remarks>
    /// This class is used to model a recipe in a cooking application. It includes properties for the recipe's name, ingredients, instructions, and preparation time.
    /// </remarks>
    [Serializable]
    public class Recipe
    {
        /// <summary>
        /// Initializes a new empty instance <see cref="Recipe"/> class.
        /// </summary>
        public Recipe()
        {
            Id = Guid.NewGuid().ToString();
            Rating = 0f;
        }

        /// <summary>
        /// Initializes a new instance <see cref="Recipe"/> class.
        /// <para>
        /// Used to serialize and deserialize an object.
        /// </para>
        /// </summary>
        /// <param name="id">The unique identifier for the recipe.</param>
        /// <param name="title">The title of the recipe.</param>
        /// <param name="mainImg">The main image of the recipe.</param>
        /// <param name="cookingTime">The cooking time in minutes.</param>
        /// <param name="calories">The calories per serving.</param>
        /// <param name="authorsId">The identifier of the author.</param>
        /// <param name="numberOfServings">The number of servings.</param>
        /// <param name="ingredients">A list of ingredients.</param>
        /// <param name="steps">A list of cooking steps.</param>
        /// <param name="images">A list of intermediate images.</param>
        /// <param name="rating">The rating of the recipe.</param>
        public Recipe(string id, string title, string mainImg, int cookingTime, int calories, string authorsId, int numberOfServings, List<string> ingredients, List<string> steps, List<string> images, float rating = 0f)
        {
            if (string.IsNullOrEmpty(id))
            {
                Id = Guid.NewGuid().ToString();
            }
            else
            {
                Id = id;
            }

            Title = title;
            MainImg = mainImg;
            CookingTime = cookingTime;
            Calories = calories;
            AuthorsId = authorsId;
            Rating = rating;
            NumberOfServings = numberOfServings;
            Ingredients = ingredients;
            Steps = steps;
            Images = images;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the recipe.
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the title for the recipe.
        /// </summary>
        /// <remarks>
        /// The title must be a string with a maximum length of 50 characters and cannot contain any of the following invalid characters: @#$%*.
        /// </remarks>
        [StringLength(50)]
        [InvalidCharsAttribute("@#$%*")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the main image for the recipe in the "png" format. 
        /// </summary>
        /// <remarks>
        /// The image must be an extension with a "png" format.
        /// </remarks>
        [FileExtensions(Extensions = "png", ErrorMessage = "Wrong extensions")]
        public string MainImg { get; set; }

        /// <summary>
        /// Gets or sets the cooking time in minutes for the recipe.
        /// </summary>
        /// <remarks>
        /// The cooking time must be a minimum range of 0 and a maximum range of 300000 minutes.
        /// </remarks>
        [Range(0, 300000)]
        public int CookingTime { get; set; }

        /// <summary>
        /// Gets or sets the calories for the recipe.
        /// </summary>
        /// <remarks>
        /// The calories must be a minimum range of 0 and a maximum range of 5000.
        /// </remarks>
        [Range(0, 5000)]
        public int Calories { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the author for the recipe.
        /// </summary>
        public string AuthorsId { get; set; }

        /// <summary>
        /// Gets or sets the rating for the recipe.
        /// </summary>
        /// <remarks>
        /// The rating must be a minimum range of 0 and a maximum range of 10.
        /// </remarks>
        [Range(0.0, 10.0)]
        public float Rating { get; set; }

        /// <summary>
        /// Gets or sets the number of servings for the recipe.
        /// </summary>
        /// <remarks>
        /// The number of servings must be a minimum range of 0 and a maximum range of 20.
        /// </remarks>
        [Range(0, 20)]
        public int NumberOfServings { get; set; }

        /// <summary>
        /// Gets or sets the list of ingredients for the recipe.
        /// </summary>
        public List<string> Ingredients { get; set; }

        /// <summary>
        /// Gets or sets the list of cooking steps for the recipe.
        /// </summary>
        public List<string> Steps { get; set; }

        /// <summary>
        /// Gets or sets the list of intermediate images for the recipe.
        /// </summary>
        /// <remarks>
        /// The images must be an extension with a "png" format.
        /// </remarks>
        [FilesExtensions("png")]
        public List<string> Images { get; set; }
    }
}

