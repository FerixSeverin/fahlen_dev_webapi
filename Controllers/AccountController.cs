using System.Collections.Generic;
using AutoMapper;
using fahlen_dev_webapi.Data;
using fahlen_dev_webapi.Dtos;
using fahlen_dev_webapi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace fahlen_dev_webapi.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IFoodDBRepo _repository;
        private readonly IMapper _mapper;

        public AccountController(IFoodDBRepo repository, IMapper mapper) {
                _repository = repository;
                _mapper = mapper;
            }  

            [HttpGet]
            public ActionResult <IEnumerable<AccountRead>> GetAllAccounts() {
                var accountItems = _repository.GetAllAccounts();
                return Ok(_mapper.Map<IEnumerable<AccountRead>>(accountItems));
            }

            [HttpGet("{id}", Name = "GetAccountById")]
            public ActionResult<AccountRead> GetAccountById(int id) {
                var accountItem = _repository.GetAccountById(id);
                if (accountItem != null)
                    return Ok(_mapper.Map<AccountRead>(accountItem));
                
                return NotFound();
            }

            [HttpPost]
            public ActionResult<AccountRead> CreateAccount(AccountCreate accountCreate) {
                var accountModel = _mapper.Map<Account>(accountCreate);
                _repository.CreateAccount(accountModel);
                _repository.SaveChanges();

                var accountRead = _mapper.Map<AccountRead>(accountModel);
                return CreatedAtRoute(nameof(GetAccountById), new {Id = accountRead.Id}, accountRead);
            }

            

            // // POST api/commands
            // [HttpPost]
            // public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto) {
            //     var commandModel = _mapper.Map<Command>(commandCreateDto);
            //     _repository.CreateCommand(commandModel);
            //     _repository.SaveChanges();

            //     var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            //     return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDto.Id}, commandReadDto);
            //     //return Ok(commandReadDto);
            // }

            // //PUT api/commands/{id}
            // [HttpPut("{id}")]
            // public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto) {
            //     var commandModelFromRepo = _repository.GetCommandById(id);
            //     if(commandModelFromRepo == null)
            //         return NotFound();
                
            //     _mapper.Map(commandUpdateDto, commandModelFromRepo);
                
            //     _repository.UpdateCommand(commandModelFromRepo);

            //     _repository.SaveChanges();

            //     return NoContent();
            // }

            // //PATCH api/commands/{id}
            // [HttpPatch("{id}")]
            // public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc) {
            //     var commandModelFromRepo = _repository.GetCommandById(id);
            //     if(commandModelFromRepo == null)
            //         return NotFound();

            //     var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            //     patchDoc.ApplyTo(commandToPatch, ModelState);
            //     if(!TryValidateModel(commandToPatch)) {
            //         return ValidationProblem(ModelState);
            //     }

            //     _mapper.Map(commandToPatch, commandModelFromRepo);
            //     _repository.UpdateCommand(commandModelFromRepo);
            //     _repository.SaveChanges();

            //     return NoContent();
            // }

            // [HttpDelete("{id}")]
            // public ActionResult DeleteCommand(int id) {
            //     var commandModelFromRepo = _repository.GetCommandById(id);
            //     if(commandModelFromRepo == null)
            //         return NotFound();
                
            //     _repository.DeleteCommand(commandModelFromRepo);
            //     _repository.SaveChanges();

            //     return NoContent();
            // }
    }
}