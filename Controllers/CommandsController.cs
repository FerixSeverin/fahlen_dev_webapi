using System.Collections.Generic;
using fahlen_dev_webapi.Data;
using fahlen_dev_webapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace fahlen_dev_webapi.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
    private readonly ICommanderRepo _repository;

    public CommandsController(ICommanderRepo repository) {
            _repository = repository;
        }  
        // private readonly MockCommanderRepo _repository = new MockCommanderRepo();
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands() {
            var commandItems = _repository.GetAllCommands();

            return Ok(commandItems);
        }

        
        [HttpGet("{id}")]
        public ActionResult <Command> GetCommandById(int id) {
            var commandItem = _repository.GetCommandById(id);

            return Ok(commandItem);
        }
    }
}