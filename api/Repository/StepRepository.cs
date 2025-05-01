using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Step;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StepRepository : IStepRepository
    {
        private readonly ApplicationDBContext _context;
        public StepRepository(ApplicationDBContext context)
        {
            _context = context;
        }        
        public async Task<List<Step>> GetAllAsync()
        {
            return await _context.Steps.ToListAsync();
        }

        public async Task<Step?> GetByIdAsync(int id)
        {
            return await _context.Steps.FindAsync(id);
        }
        public async Task<List<Step>> GetByQuestIdAsync(int questId)
        {
            return await _context.Steps.Where(s => s.QuestId == questId).ToListAsync();
        }

        public async Task<Step> AddAsync(Step stepModel)
        {
            await _context.Steps.AddAsync(stepModel);
            await _context.SaveChangesAsync();
            return stepModel;
        }

        public async Task<Step?> UpdateAsync(int id, UpdateStepRequestDto stepDto)
        {
            var existingStep = await _context.Steps.FindAsync(id);

            if (existingStep == null)
            {
                return null;
            }

            existingStep.Name = stepDto.Name;
            existingStep.Description = stepDto.Description;

            await _context.SaveChangesAsync();

            return existingStep;
        }

        public async Task<Step?> DeleteAsync(int id)
        {
            var stepModel = await _context.Steps.FirstOrDefaultAsync(s => s.Id == id);

            if (stepModel == null)
            {
                return null;
            }

            _context.Steps.Remove(stepModel);
            await _context.SaveChangesAsync();
            
            return stepModel;
        }
    }
}