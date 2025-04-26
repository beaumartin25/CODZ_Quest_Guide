using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Map;

namespace api.Dtos.Game
{
    public class UpdateGameRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public List<MapDto> Maps { get; set; }
    }
}