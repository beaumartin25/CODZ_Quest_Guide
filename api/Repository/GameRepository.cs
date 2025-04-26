using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Game;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDBContext _context;
        public GameRepository(ApplicationDBContext context)
        {
            _context = context;
        }        
        public async Task<List<Game>> GetAllAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game?> GetByIdAsync(int id)
        {
            return await _context.Games.FindAsync(id);
        }

        public async Task<Game> AddAsync(Game gameModel)
        {
            await _context.Games.AddAsync(gameModel);
            await _context.SaveChangesAsync();
            return gameModel;
        }

        public async Task<Game?> UpdateAsync(int id, UpdateGameRequestDto gameDto)
        {
            var existingGame = await _context.Games.FindAsync(id);

            if (existingGame == null)
            {
                return null;
            }

            existingGame.Name = gameDto.Name;
            existingGame.ImageUrl = gameDto.ImageUrl;

            await _context.SaveChangesAsync();

            return existingGame;
        }

        public async Task<Game?> DeleteAsync(int id)
        {
            var gameModel = await _context.Games
                .Include(g => g.Maps)
                .ThenInclude(g => g.Quests)
                .ThenInclude(q => q.Steps)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (gameModel == null)
            {
                return null;
            }

             _context.Games.Remove(gameModel);
            
            // Cascading deletion
            foreach (var map in gameModel.Maps.ToList())
            {
                _context.Maps.Remove(map);

                foreach (var quest in map.Quests.ToList())
                {
                    _context.Quests.Remove(quest);

                    foreach (var step in quest.Steps.ToList())
                    {
                        _context.Steps.Remove(step);
                    }
                }
            }

            await _context.SaveChangesAsync();            

            return gameModel;
        }
    }
}