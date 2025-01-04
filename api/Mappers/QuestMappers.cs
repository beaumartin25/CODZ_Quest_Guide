using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Quest;
using api.Models;

namespace api.Mappers
{
    public static class QuestMappers
    {
        public static QuestDto ToQuestDto(this Quest questModel)
        {
            return new QuestDto
            {
                Id = questModel.Id,
                Name = questModel.Name,
                MainQuest = questModel.MainQuest
            };
        }
    }
}