using Microsoft.AspNetCore.Mvc;
using RecipesBook.Models;
using RecipesBook.Repositories;
using System.Text.Json;

namespace RecipesBookWeb.Server.Controllers
{
    public class ApiController : Controller
    {
        private readonly RecipeContext _context;

        public ApiController(RecipeContext context)
        {
            _context = context;
        }

        private List<Recipe> ReadAll()
        {
            return _context.Recipes.ToList();
        }

        private Recipe ReadOne(string id)
        {
            Recipe model = _context.Recipes.Find(id);
            return model;
        }

        [HttpGet]
        public IActionResult Recipes()
        {
            Response.ContentType = "application/json";
            List<Recipe> recipes = ReadAll();
            return recipes == null ? NotFound() : Ok(recipes);
        }

        [HttpGet]
        public IActionResult Recipe([FromRoute] string id)
        {
            Response.ContentType = "application/json";
            Recipe recipe = ReadOne(id);
            string response = JsonSerializer.Serialize(recipe);
            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet]
        public IActionResult Filter([FromQuery] string filter)
        {
            Response.ContentType = "application/json";
            List<Recipe> recipes = ReadAll();
            string response = JsonSerializer.Serialize(recipes);
            return response == null ? NotFound() : Ok(response);
        }

        [HttpPost]
        private void Create([FromBody] Recipe model)
        {
            _context.Recipes.Add(model);
            _context.SaveChanges();
        }

        [HttpPost]
        private void Update([FromBody] Recipe model)
        {
            _context.Recipes.Update(model);
            _context.SaveChanges();

        }

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
    

