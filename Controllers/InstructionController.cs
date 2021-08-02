using System.Collections.Generic;
using AutoMapper;
using fahlen_dev_webapi.Data;
using fahlen_dev_webapi.Dtos;
using fahlen_dev_webapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace fahlen_dev_webapi.Controllers
{
  [Route("api/instruction")]
  [ApiController]
  public class InstructionController : ControllerBase
  {
    private readonly IFoodDBRepo _repository;
    private readonly IMapper _mapper;

    public InstructionController(IFoodDBRepo repository, IMapper mapper) {
      _repository = repository;
      _mapper = mapper;
    }

    [HttpGet]
    public ActionResult <IEnumerable<InstructionRead>> GetAllInstructions() {
      var instructionItems = _repository.GetAllInstructions();
      return Ok(_mapper.Map<IEnumerable<InstructionRead>>(instructionItems));
    }

    [HttpGet("{id}", Name = "GetInstructionById")]
    public ActionResult<InstructionRead> GetInstructionById(int id) {
      var instructionItem = _repository.GetInstructionById(id);
      if (instructionItem != null)
        return Ok(_mapper.Map<InstructionRead>(instructionItem));
      
      return NotFound();
    }

    [HttpPost]
    public ActionResult<InstructionRead> CreateMeasure(InstructionCreate instructionCreate) {
      var instructionModel = _mapper.Map<Instruction>(instructionCreate);
      _repository.CreateInstruction(instructionModel);
      _repository.SaveChanges();

      var instructionRead = _mapper.Map<InstructionRead>(instructionModel);
      return CreatedAtRoute(nameof(GetInstructionById), new {Id = instructionRead.Id}, instructionRead);
    }
    
    [HttpDelete("{id}")]
    public ActionResult DeleteInstruction(int id) {
      var instructionModelFromRepo = _repository.GetInstructionById(id);
      if(instructionModelFromRepo == null)
          return NotFound();
      
      _repository.DeleteInstruction(instructionModelFromRepo);
      _repository.SaveChanges();

      return NoContent();
    }
  }
}