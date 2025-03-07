using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IQuestRepository
    {
        Task<List<Quest>> GetAllAsync();
        Task<Quest?> GetByIdAsync(int id);
        Task<List<Quest>> GetByMapIdAsync(int mapId);
    }
}