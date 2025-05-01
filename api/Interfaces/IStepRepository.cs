using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Step;
using api.Models;

namespace api.Interfaces
{
    public interface IStepRepository
    {
        Task<List<Step>> GetAllAsync();
        Task<Step?> GetByIdAsync(int id);
        Task<List<Step>> GetByQuestIdAsync(int questId);
        Task<Step> AddAsync(Step step);
        Task<Step?> UpdateAsync(int id, UpdateStepRequestDto stepDto);
        Task<Step?> DeleteAsync(int id);
    }
}