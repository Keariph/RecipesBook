using Microsoft.AspNetCore.Mvc;
using RecipesBook.Models;
using RecipesBook.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace RecipesBookWeb.Server.Controllers
{
    /// <summary>
    /// Provides API endpoints for managing recipes.
    /// </summary>
    /// <remarks>
    /// This controller class is responsible for handling HTTP requests related to recipes, such as retrieving all recipes, getting a specific recipe by ID, filtering recipes, creating a new recipe, updating an existing recipe, and deleting a recipe.
    /// </remarks>
    public class ApiController : Controller
    {
        private readonly RecipeContext _context;

        private List<Recipe> ReadRecipes(int take = 10, int skip = 0)
        {
            return _context.Recipes.Skip(skip).Take(take).ToList();
        }

        private Recipe ReadOne(string id)
        {
            Recipe model = _context.Recipes.Find(id);
            return model;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiController"/> class.
        /// </summary>
        /// <param name="context">The <see cref="RecipeContext"/> instance used for database operations.</param>
        public ApiController(RecipeContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a chunk of recipes from the database.
        /// </summary>
        /// <returns>A list of recipes or a 404 Not Found response if no recipes are found.</returns>
        [HttpGet]
        public IActionResult Recipes([FromQuery] int take = 10, int skip = 0)
        {
            Response.ContentType = "application/json";
            List<Recipe> recipes = ReadRecipes(take, skip);
            return recipes == null ? NotFound() : Ok(recipes);
        }

        /// <summary>
        /// Retrieves a specific recipe by its ID.
        /// </summary>
        /// <param name="id">The ID of the recipe to retrieve.</param>
        /// <returns>The requested recipe or a 404 Not Found response if the recipe is not found.</returns>
        [HttpGet]
        public IActionResult Recipe([FromRoute] string id)
        {
            Response.ContentType = "application/json";
            Recipe recipe = ReadOne(id);
            string response = JsonSerializer.Serialize(recipe);
            return response == null ? NotFound() : Ok(response);
        }

        /// <summary>
        /// Filters recipes based on a query parameter.
        /// </summary>
        /// <param name="filter">The filter query parameter.</param>
        /// <returns>A list of filtered recipes or a 404 Not Found response if no recipes match the filter.</returns>
        [HttpGet]
        public IActionResult Filter([FromQuery] string filter, int take = 10, int skip = 0)
        {
            Response.ContentType = "application/json";
            List<Recipe> recipes = ReadRecipes(take, skip);
            string response = JsonSerializer.Serialize(recipes);
            return response == null ? NotFound() : Ok(response);
        }

        /// <summary>
        /// Creates a new recipe.
        /// </summary>
        /// <param name="model">The recipe model to create.</param>
        /// <returns>A 200 OK response if the recipe is successfully created, or a 400 Bad Request response if the model is invalid.</returns>
        [HttpPost]
        private IActionResult Create([FromBody] Recipe model)
        {
            var context = new ValidationContext(model);
            var result = new List<ValidationResult>();

            if (!Validator.TryValidateObject(model, context, result, true))
            {
                return BadRequest(result);
            }
            else
            {
                _context.Recipes.Add(model);
                _context.SaveChanges();
                return Ok();
            }
        }

        /// <summary>
        /// Updates an existing recipe.
        /// </summary>
        /// <param name="model">The recipe model to update.</param>
        /// <returns>A 200 OK response if the recipe is successfully updated, or a 400 Bad Request response if the model is invalid.</returns>
        [HttpPost]
        private IActionResult Update([FromBody] Recipe model)
        {
            var context = new ValidationContext(model);
            var result = new List<ValidationResult>();
            if (!Validator.TryValidateObject(model, context, result, true))
            {
                return BadRequest(result);
            }
            else
            {
                _context.Recipes.Update(model);
                _context.SaveChanges();
                return Ok();
            }
        }

        /// <summary>
        /// Deletes a recipe by its ID.
        /// </summary>
        /// <param name="id">The ID of the recipe to delete.</param>
        [HttpDelete]
        private void Delete([FromRoute] string id)
        {
            Recipe model = _context.Recipes.Find(id);

            if (model != null)
            {
                _context.Recipes.Remove(model);
                _context.SaveChanges();
            }
        }
    }
}
    

