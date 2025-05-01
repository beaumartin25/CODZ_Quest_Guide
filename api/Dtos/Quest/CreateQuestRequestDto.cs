using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Quest
{
    public class CreateQuestRequestDto
    {
        public string Name { get; set; }
         public bool MainQuest { get; set; }
        public int MapId { get; set; }
    }
}