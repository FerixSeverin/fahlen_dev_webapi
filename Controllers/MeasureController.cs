using System.Collections.Generic;
using AutoMapper;
using fahlen_dev_webapi.Data;
using fahlen_dev_webapi.Dtos;
using fahlen_dev_webapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace fahlen_dev_webapi.Controllers
{
    [Route("api/measure")]
    [ApiController]
    public class MeasureController : ControllerBase
    {
        private readonly IFoodDBRepo _repository;
        private readonly IMapper _mapper;

        public MeasureController(IFoodDBRepo repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<MeasureRead>> GetAllMeasures() {
            var measureItems = _repository.GetAllMeasures();
            return Ok(_mapper.Map<IEnumerable<MeasureRead>>(measureItems));
        }

        [HttpGet("{id}", Name = "GetMeasureById")]
        public ActionResult<MeasureRead> GetMeasureById(int id) {
            var measureItem = _repository.GetMeasureById(id);
            if (measureItem != null)
                return Ok(_mapper.Map<MeasureRead>(measureItem));
            
            return NotFound();
        }

        [HttpPost]
        public ActionResult<MeasureRead> CreateMeasure(MeasureCreate measureCreate) {
            var measureModel = _mapper.Map<Measure>(measureCreate);
            _repository.CreateMeasure(measureModel);
            _repository.SaveChanges();

            var measureRead = _mapper.Map<MeasureRead>(measureModel);
            return CreatedAtRoute(nameof(GetMeasureById), new {Id = measureRead.Id}, measureRead);
        }
        
        [HttpDelete("{id}")]
        public ActionResult DeleteMeasure(int id) {
            var measureModelFromRepo = _repository.GetMeasureById(id);
            if(measureModelFromRepo == null)
                return NotFound();
            
            _repository.DeleteMeasure(measureModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}