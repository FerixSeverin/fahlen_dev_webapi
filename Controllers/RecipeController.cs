
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using fahlen_dev_webapi.Data;
using fahlen_dev_webapi.Dtos;
using fahlen_dev_webapi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fahlen_dev_webapi.Controllers
{
    [Route("api/recipe")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RecipeController : ControllerBase
    {
        private readonly IFoodDBRepo _repository;
        private readonly IMapper _mapper;

        public RecipeController(IFoodDBRepo repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<RecipeRead>> GetAllRecipes() {
            var recipeItems = _repository.GetAllRecipes();
            return Ok(_mapper.Map<IEnumerable<RecipeRead>>(recipeItems));
        }

        [HttpGet("{id}", Name = "GetRecipeById")]
        public ActionResult<RecipeRead> GetRecipeById(int id) {
            var recipeItem = _repository.GetRecipeById(id);
            if (recipeItem != null)
                return Ok(_mapper.Map<RecipeRead>(recipeItem));
            
            return NotFound();
        }

        [HttpPost]
        public ActionResult<RecipeRead> CreateRecipe(RecipeCreate recipeCreate) {
            var recipeModel = _mapper.Map<Recipe>(recipeCreate);
            _repository.CreateRecipe(recipeModel);
            _repository.SaveChanges();

            var recipeRead = _mapper.Map<RecipeRead>(recipeModel);
            return CreatedAtRoute(nameof(GetRecipeById), new {Id = recipeRead.Id}, recipeRead);
        }
        
        [HttpDelete("{id}")]
        public ActionResult DeleteRecipe(int id) {
            var recipeModelFromRepo = _repository.GetRecipeById(id);
            if(recipeModelFromRepo == null)
                return NotFound();
            
            _repository.DeleteRecipe(recipeModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpGet("all/{id}", Name = "GetRecipeEditById")]
        public ActionResult <RecipeReadWithRecipeGroups> GetRecipeEditById(int id) {
            var recipeItem = _repository.GetRecipeById(id);
            if (recipeItem != null) {
                var recipeGroupItems = _repository.GetAllRecipeGroupsByAccountId(id);
                if (recipeGroupItems != null) {
                    recipeItem.RecipeGroups = recipeGroupItems.ToList();
                    foreach (var recipeGroup in recipeItem.RecipeGroups) {
                        var ingredientItem = _repository.GetAllIngredientsByRecipeGroupId(recipeGroup.Id);
                        if (ingredientItem != null) {
                            recipeGroup.Ingredients = ingredientItem.ToList();
                            foreach (var ingredient in recipeGroup.Ingredients) {
                                var maesureItem = _repository.GetMeasureById(ingredient.MeasureId);
                                if (maesureItem != null) {
                                    ingredient.Measure = maesureItem;
                                }
                            }
                        }
                    }
                }
                
                var measureItems = _repository.GetAllMeasures();
                var recipeReadItem = _mapper.Map<RecipeReadWithRecipeGroups>(recipeItem);
                if (measureItems != null) {
                    recipeReadItem.Measures = _mapper.Map<IEnumerable<MeasureRead>>(measureItems).ToList();
                }
                var instructionItems = _repository.GetAllInstructionsByRecipeId(id);
                if (instructionItems != null) {
                    recipeReadItem.Instructions = _mapper.Map<IEnumerable<InstructionRead>>(instructionItems).ToList();
                }

                return Ok(recipeReadItem); 
            }

            return NotFound();
        }
    }
}