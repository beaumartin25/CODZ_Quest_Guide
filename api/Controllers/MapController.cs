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
    }
}