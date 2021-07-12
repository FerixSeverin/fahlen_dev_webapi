using System.Collections.Generic;
using AutoMapper;
using fahlen_dev_webapi.Data;
using fahlen_dev_webapi.Dtos;
using fahlen_dev_webapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace fahlen_dev_webapi.Controllers
{
    [Route("api/ingredient")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IFoodDBRepo _repository;
        private readonly IMapper _mapper;

        public IngredientController(IFoodDBRepo repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<IngredientRead>> GetAllIngredients() {
            var ingredientItems = _repository.GetAllIngredients();
            return Ok(_mapper.Map<IEnumerable<IngredientRead>>(ingredientItems));
        }

        [HttpGet("{id}", Name = "GetIngredientById")]
        public ActionResult<RecipeRead> GetIngredientById(int id) {
            var ingredientItem = _repository.GetIngredientById(id);
            if (ingredientItem != null)
                return Ok(_mapper.Map<IngredientRead>(ingredientItem));
            
            return NotFound();
        }

        public ActionResult<IngredientRead> CreateIngredient(IngredientCreate ingredientCreate) {
            var ingredientModel = _mapper.Map<Ingredient>(ingredientCreate);
            _repository.CreateIngredient(ingredientModel);
            _repository.SaveChanges();

            var ingredientRead = _mapper.Map<IngredientRead>(ingredientModel);
            return CreatedAtRoute(nameof(GetIngredientById), new {Id = ingredientRead.Id}, ingredientRead);
        }
        
        [HttpDelete("{id}")]
        public ActionResult DeleteIngredient(int id) {
            var ingredientModelFromRepo = _repository.GetIngredientById(id);
            if(ingredientModelFromRepo == null)
                return NotFound();
            
            _repository.DeleteIngredient(ingredientModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}