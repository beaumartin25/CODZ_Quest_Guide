using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IMapRepository
    {
        Task<List<Map>> GetAllAsync();
        Task<Map?> GetByIdAsync(int id);
    }
}