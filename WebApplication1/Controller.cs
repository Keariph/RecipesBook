using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace RecipesBook
{
    [ApiController]
    [Route("/api")]
    public class Controller : ControllerBase
    {
        Repository Repository = new Repository();

        [HttpGet("/")]
        public ActionResult GetAllRecipes() 
        {
            Response.ContentType = "application/json";
            List<Recipe> recipes = Repository.ReadAll();
            string response = JsonSerializer.Serialize(recipes);
            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet("/recipe/{id}")]
        public ActionResult GetRecipe([FromRoute] string id) 
        {
            Recipe recipe = Repository.ReadOne(id);
            string response = JsonSerializer.Serialize(recipe);
            return response == null ? NotFound() : Ok(response);
        }
    }
}
