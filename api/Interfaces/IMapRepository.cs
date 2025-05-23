using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Map;
using api.Models;

namespace api.Interfaces
{
    public interface IMapRepository
    {
        Task<List<Map>> GetAllAsync();
        Task<Map?> GetByIdAsync(int id);
        Task<List<Map>> GetByGameIdAsync(int gameId);
        Task<Map> AddAsync(Map map);
        Task<Map?> UpdateAsync(int id, UpdateMapRequestDto mapDto);
        Task<Map?> DeleteAsync(int id);
    }
}