using System.Collections.Generic;
using AutoMapper;
using fahlen_dev_webapi.Data;
using fahlen_dev_webapi.Dtos;
using fahlen_dev_webapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace fahlen_dev_webapi.Controllers
{
    [Route("api/recipegroup")]
    [ApiController]
    public class RecipeGroupController : ControllerBase
    {
    private readonly IFoodDBRepo _repository;
    private readonly IMapper _mapper;

    public RecipeGroupController(IFoodDBRepo repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<RecipeGroupRead>> GetAllRecipeGroups() {
            var recipeGroupItems = _repository.GetAllRecipeGroups();
            return Ok(_mapper.Map<IEnumerable<RecipeGroupRead>>(recipeGroupItems));
        }

        [HttpGet("{id}", Name = "GetRecipeGroupById")]
        public ActionResult<RecipeGroupRead> GetRecipeGroupById(int id) {
            var recipeGroupItem = _repository.GetRecipeGroupById(id);
            if (recipeGroupItem != null) 
                return Ok(_mapper.Map<RecipeGroupRead>(recipeGroupItem));
            return NotFound();
        }

        [HttpPost]
        public ActionResult<RecipeGroupRead> CreateRecipeGroup(RecipeGroupCreate recipeGroupCreate) {
            var recipeGroupModel = _mapper.Map<RecipeGroup>(recipeGroupCreate);
            _repository.CreateRecipeGroup(recipeGroupModel);
            _repository.SaveChanges();

            var recipeGroupRead = _mapper.Map<RecipeGroupRead>(recipeGroupModel);
            return CreatedAtRoute(nameof(GetRecipeGroupById), new {Id = recipeGroupRead.Id}, recipeGroupRead);
        }
        
        [HttpDelete("{id}")]
        public ActionResult DeleteRecipeGroup(int id) {
            var recipeGroupModelFromRepo = _repository.GetRecipeGroupById(id);
            if(recipeGroupModelFromRepo == null)
                return NotFound();
            
            _repository.DeleteRecipeGroup(recipeGroupModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpGet("recipe/{id}", Name = "GetRecipeGroupsByRecipeId")]
        public ActionResult <IEnumerable<RecipeGroupRead>> GetRecipeGroupsByRecipeId(int id) {
            var recipeGroupItems = _repository.GetAllRecipeGroupsByAccountId(id);
            if (recipeGroupItems != null)
                return Ok(_mapper.Map<IEnumerable<RecipeGroupRead>>(recipeGroupItems));
            return NotFound();
        }

        
    }
}