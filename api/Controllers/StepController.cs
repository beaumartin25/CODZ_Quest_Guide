using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;


namespace api.Controllers
{
    [Route("api/step")]
    [ApiController]
    public class StepController : ControllerBase
    {
        private readonly IStepRepository _stepRepo;
        public StepController(IStepRepository stepRepo)
        {
            _stepRepo = stepRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var steps = await _stepRepo.GetAllAsync();
            
            var stepDto = steps.Select(s => s.ToStepDto());

            return Ok(steps);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var step = await _stepRepo.GetByIdAsync(id);

            if(step == null)
            {
                return NotFound();
            }

            return Ok(step.ToStepDto());
        }
        [HttpGet("quest/{questId}")]
        public async Task<IActionResult> GetByQuestId([FromRoute] int questId)
        {
            var steps = await _stepRepo.GetByQuestIdAsync(questId);

            if (!steps.Any())
            {
                return NotFound($"No steps found for quest ID {questId}.");
            }

            var stepDtos = steps.Select(m => m.ToStepDto());
            return Ok(stepDtos);
        }
    }
}