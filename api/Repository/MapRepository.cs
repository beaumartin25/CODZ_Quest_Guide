using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Map;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class MapRepository : IMapRepository
    {
        private readonly ApplicationDBContext _context;
        public MapRepository(ApplicationDBContext context)
        {
            _context = context;
        }        

        public async Task<List<Map>> GetAllAsync()
        {
            return await _context.Maps.ToListAsync();
        }

        public async Task<Map?> GetByIdAsync(int id)
        {
            return await _context.Maps.FindAsync(id);
        }
        public async Task<List<Map>> GetByGameIdAsync(int gameId)
        {
            return await _context.Maps.Where(m => m.GameId == gameId).ToListAsync();
        }

        public async Task<Map> AddAsync(Map mapModel)
        {
            await _context.Maps.AddAsync(mapModel);
            await _context.SaveChangesAsync();
            return mapModel;
        }

        public async Task<Map?> UpdateAsync(int id, UpdateMapRequestDto mapDto)
        {
            var existingMap = await _context.Maps.FindAsync(id);

            if (existingMap == null)
            {
                return null;
            }

            existingMap.Name = mapDto.Name;
            existingMap.ImageUrl = mapDto.ImageUrl;

            await _context.SaveChangesAsync();

            return existingMap;
        }

        public async Task<Map?> DeleteAsync(int id)
        {
            var mapModel = await _context.Maps
                .Include(m => m.Quests)
                .ThenInclude(q => q.Steps)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mapModel == null)
            {
                return null;
            }

            _context.Maps.Remove(mapModel);

            // Cascading deletion
            foreach (var quest in mapModel.Quests.ToList())
            {
                _context.Quests.Remove(quest);

                foreach (var step in quest.Steps.ToList())
                {
                    _context.Steps.Remove(step);
                }
            }

            await _context.SaveChangesAsync();
            
            return mapModel;
        }
    }
}