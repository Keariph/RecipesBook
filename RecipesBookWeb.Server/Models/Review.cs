using System.ComponentModel.DataAnnotations;

namespace RecipesBookWeb.Server.Models
{
    /// <summary>
    /// Represents a review with details such as author ID, recipe ID, estimate and message.
    /// </summary>
    [Serializable]
    public class Review
    {
        /// <summary>
        /// Initializes a new instance <see cref="Review"/> class.
        /// </summary>
        /// <param name="id">The unique identifier for the review.</param>
        /// <param name="authorID">The unique identifier for the author of a review.</param>
        /// <param name="recipeID">The unique identifier of the recipe that the reviewent refers to.</param>
        /// <param name="message">The message of the review.</param>
        /// <param name="estimate">The estimate of the recipe that the review refers to.</param>
        public Review(string id, string authorID, string recipeID, string message, int estimate)
        {
            Id = id;
            AuthorID = authorID;
            RecipeID = recipeID;
            Message = message;
            Estimate = estimate;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the review.
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the author of a review.
        /// </summary>
        public string AuthorID { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the recipe that the review refers to.
        /// </summary>
        public string RecipeID { get; set; }

        /// <summary>
        /// Gets or sets the  message of the review.
        /// </summary>
        /// <remarks>
        /// The message must be a string with a maximum length of 250 characters
        /// </remarks>
        [StringLength(250)]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the estimate of the recipe that the review refers to.
        /// </summary>
        /// <remarks>
        /// The estimate must be a minimum range of 0 and a maximum range of 5.
        /// </remarks>
        [Range(0,5)]
        public int Estimate { get; set; }
    }
}
