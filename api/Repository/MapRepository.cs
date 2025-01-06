using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
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
    }
}