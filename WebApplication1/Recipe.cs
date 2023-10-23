using Microsoft.EntityFrameworkCore;
using System.Net;

namespace RecipesBook
{
    [Serializable]
    public class Recipe
    {
        public Recipe()
        {
            Id = Guid.NewGuid().ToString();
        }

        public Recipe(string title, int cookingTime, int calories, string authorsId, float rating, int numberOfServings, List<string> ingredients, List<string> steps, List<string> images)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            CookingTime = cookingTime;
            Calories = calories;
            AuthorsId = authorsId;
            Rating = rating;
            NumberOfServings = numberOfServings;
            Ingredients = ingredients;
            Steps = steps;
            Images = images;
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public int CookingTime { get; set; }
        public int Calories { get; set; }
        public string AuthorsId { get; set; }
        public float Rating { get; set; }
        public int NumberOfServings { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> Steps { get; set; }
        public List<string> Images { get; set; }
    }
}

