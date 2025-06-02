using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Map;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/map")]
    [ApiController]
    public class MapController : ControllerBase
    {
        private readonly IMapRepository _mapRepo;
        public MapController(IMapRepository mapRepo)
        {
            _mapRepo = mapRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var maps = await _mapRepo.GetAllAsync();
            
            var mapDto = maps.Select(s => s.ToMapDto());

            return Ok(maps);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var map = await _mapRepo.GetByIdAsync(id);

            if(map == null)
            {
                return NotFound();
            }

            return Ok(map.ToMapDto());
        }
        [HttpGet("game/{gameId}")]
        public async Task<IActionResult> GetByGameId([FromRoute] int gameId)
        {
            var maps = await _mapRepo.GetByGameIdAsync(gameId);

            if (!maps.Any())
            {
                return NotFound($"No maps found for game ID {gameId}.");
            }

            var mapDtos = maps.Select(m => m.ToMapDto());
            return Ok(mapDtos);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateMap([FromBody] CreateMapRequestDto mapDto)
        {
            var mapModel = mapDto.ToMapFromCreateDto();

            await _mapRepo.AddAsync(mapModel);

            return CreatedAtAction(nameof(GetById), new { id = mapModel.Id }, mapModel.ToMapDto());
        }

        [HttpPut]
        [Route("{id:int}")] 
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateMap([FromRoute] int id, [FromBody] UpdateMapRequestDto UpdateDto)
        {
            var mapModel = await _mapRepo.UpdateAsync(id, UpdateDto);

            if(mapModel == null)
            {
                return NotFound();
            }

            return Ok(mapModel.ToMapDto());
        }

        [HttpDelete]
        [Route("{id:int}")] 
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteMap([FromRoute] int id)
        {
            var mapModel = await _mapRepo.DeleteAsync(id);

            if(mapModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}