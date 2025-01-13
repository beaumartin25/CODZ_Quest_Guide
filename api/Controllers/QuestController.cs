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
    }
}