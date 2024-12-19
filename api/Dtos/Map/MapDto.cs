using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Quest;

namespace api.Dtos.Map
{
    public class MapDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int? GameId { get; set; }
        public List<QuestDto> Quests { get; set; }
    }
}