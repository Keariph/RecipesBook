using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace RecipesBook
{
    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase
    {
        Repository Repository = new Repository();

        [Route("/")]
        public ActionResult GetRecipes() 
        {
            List<Recipe> recipes = Repository.ReadAll();
            string response = JsonSerializer.Serialize(recipes);
            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet]
        [Route("/main/recipe/{id}")]
        public ActionResult PostRecipes([FromHeader] string id) 
        {
            Recipe recipe = Repository.ReadOne(id);
            string response = JsonSerializer.Serialize(recipe);
            return response == null ? NotFound() : Ok(response);
        }
    }
}
