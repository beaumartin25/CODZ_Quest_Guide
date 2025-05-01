using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Game;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IGameRepository _gameRepo;
        public GameController(ApplicationDBContext context, IGameRepository gameRepo)
        {
            _gameRepo = gameRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var games = await _gameRepo.GetAllAsync();
            
            var gameDto = games.Select(s => s.ToGameDto());

            return Ok(games);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var game = await _gameRepo.GetByIdAsync(id);

            if(game == null)
            {
                return NotFound();
            }

            return Ok(game.ToGameDto());
        }

        [HttpPost]
        //[Authorize] will need to add authorization
        public async Task<IActionResult> AddGame([FromBody] CreateGameRequestDto gameDto)
        {
            var gameModel = gameDto.ToGameFromCreateDto();
            
            await _gameRepo.AddAsync(gameModel);

            return CreatedAtAction(nameof(GetById), new { id = gameModel.Id }, gameModel.ToGameDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        //[Authorize] will need to add authorization
        public async Task<IActionResult> UpdateGame([FromRoute] int id, [FromBody] UpdateGameRequestDto updateDto)
        {
            var gameModel = await _gameRepo.UpdateAsync(id, updateDto);

            if(gameModel == null)
            {
                return NotFound();
            }

            return Ok(gameModel.ToGameDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        //[Authorize] will need to add authorization
        public async Task<IActionResult> DeleteGame([FromRoute] int id)
        {
            var gameModel = await _gameRepo.DeleteAsync(id);

            if (gameModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}