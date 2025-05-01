using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Step;

namespace api.Dtos.Quest
{
    public class UpdateQuestRequestDto
    {
        public string Name { get; set; }
         public bool MainQuest { get; set; }
    }
}