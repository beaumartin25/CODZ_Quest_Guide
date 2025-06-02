using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Quest;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/quest")]
    [ApiController]
    public class QuestController : ControllerBase
    {
        private readonly IQuestRepository _questRepo;
        public QuestController(IQuestRepository questRepo)
        {
            _questRepo = questRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var quests = await _questRepo.GetAllAsync();
            
            var mapDto = quests.Select(s => s.ToQuestDto());

            return Ok(quests);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var quest = await _questRepo.GetByIdAsync(id);

            if(quest == null)
            {
                return NotFound();
            }

            return Ok(quest.ToQuestDto());
        }
        [HttpGet("map/{mapId}")]
        public async Task<IActionResult> GetByMapId([FromRoute] int mapId)
        {
            var quests = await _questRepo.GetByMapIdAsync(mapId);

            if (!quests.Any())
            {
                return NotFound($"No quests found for map ID {mapId}.");
            }

            var questDtos = quests.Select(m => m.ToQuestDto());
            return Ok(questDtos);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddQuest([FromBody] CreateQuestRequestDto questDto)
        {
            var questModel = questDto.ToQuestFromCreateDto();

            await _questRepo.AddAsync(questModel);

            return CreatedAtAction(nameof(GetById), new { id = questModel.Id }, questModel.ToQuestDto());
        }

        [HttpPut]
        [Route("{id:int}")] 
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateQuest([FromRoute] int id, [FromBody] UpdateQuestRequestDto updateDto)
        {
            var questModel = await _questRepo.UpdateAsync(id, updateDto);

            if(questModel == null)
            {
                return NotFound();
            }

            return Ok(questModel.ToQuestDto());
        }

        [HttpDelete]
        [Route("{id:int}")] 
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteQuest([FromRoute] int id)
        {
            var questModel = await _questRepo.DeleteAsync(id);

            if(questModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}