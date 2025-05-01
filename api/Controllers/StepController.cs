using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Step;
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

        [HttpPost]
        //[Authorize] will need to add authorization
        public async Task<IActionResult> AddStep([FromBody] CreateStepRequestDto stepDto)
        {
            var stepModel = stepDto.ToStepFromCreateDto();

            await _stepRepo.AddAsync(stepModel);

            return CreatedAtAction(nameof(GetById), new { id = stepModel.Id }, stepModel.ToStepDto());
        }

        [HttpPut]
        [Route("{id:int}")] 
        //[Authorize] will need to add authorization
        public async Task<IActionResult> UpdateStep([FromRoute] int id, [FromBody] UpdateStepRequestDto updateDto)
        {
            var stepModel = await _stepRepo.UpdateAsync(id, updateDto);

            if(stepModel == null)
            {
                return NotFound();
            }

            return Ok(stepModel.ToStepDto());
        }

        [HttpDelete]
        [Route("{id:int}")] 
        //[Authorize] will need to add authorization
        public async Task<IActionResult> DeleteStep([FromRoute] int id)
        {
            var stepModel = await _stepRepo.DeleteAsync(id);

            if(stepModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}