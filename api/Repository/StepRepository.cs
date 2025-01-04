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
    }
}