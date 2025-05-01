using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Quest;
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

        public async Task<List<Quest>> GetByMapIdAsync(int mapId)
        {
            return await _context.Quests.Where(q => q.MapId == mapId).ToListAsync();
        }

        public async Task<Quest> AddAsync(Quest questModel)
        {
            await _context.Quests.AddAsync(questModel);
            await _context.SaveChangesAsync();
            return questModel;
        }

        public async Task<Quest?> UpdateAsync(int id, UpdateQuestRequestDto questDto)
        {
            var existingQuest = await _context.Quests.FindAsync(id);

            if (existingQuest == null)
            {
                return null;
            }

            existingQuest.Name = questDto.Name;
            existingQuest.MainQuest = questDto.MainQuest;

            await _context.SaveChangesAsync();

            return existingQuest;
        }

        public async Task<Quest?> DeleteAsync(int id)
        {
            var questModel = await _context.Quests
                .Include(q => q.Steps)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (questModel == null)
            {
                return null;
            }

            _context.Quests.Remove(questModel);

            foreach (var step in questModel.Steps.ToList())
            {
                _context.Steps.Remove(step);
            }

            await _context.SaveChangesAsync();
            
            return questModel;
        }
    }
}