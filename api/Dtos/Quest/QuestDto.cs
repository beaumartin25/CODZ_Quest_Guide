using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Step;

namespace api.Dtos.Quest
{
    public class QuestDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool MainQuest { get; set; }
        public int? MapId { get; set; }
        public List<StepDto> Steps { get; set; }
    }
}