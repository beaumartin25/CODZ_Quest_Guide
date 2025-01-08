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
    public class QuestRepository : IQuestRepository
    {
        private readonly ApplicationDBContext _context;
        public QuestRepository(ApplicationDBContext context)
        {
            _context = context;
        }        

        public async Task<List<Quest>> GetAllAsync()
        {
            return await _context.Quests.ToListAsync();
        }

        public async Task<Quest?> GetByIdAsync(int id)
        {
            return await _context.Quests.FindAsync(id);
        }

        public async Task<List<Quest>> GetBymapIdAsync(int mapId)
        {
            return await _context.Quests.Where(q => q.MapId == mapId).ToListAsync();
        }
    }
}