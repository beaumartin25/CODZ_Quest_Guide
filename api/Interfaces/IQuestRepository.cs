using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Quest;
using api.Models;

namespace api.Interfaces
{
    public interface IQuestRepository
    {
        Task<List<Quest>> GetAllAsync();
        Task<Quest?> GetByIdAsync(int id);
        Task<List<Quest>> GetByMapIdAsync(int mapId);
        Task<Quest> AddAsync(Quest quest);
        Task<Quest?> UpdateAsync(int id, UpdateQuestRequestDto questDto);
        Task<Quest?> DeleteAsync(int id);
    }
}