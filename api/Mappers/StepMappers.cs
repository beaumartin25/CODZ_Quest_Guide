using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Step;
using api.Models;

namespace api.Mappers
{
    public static class StepMappers
    {
        public static StepDto ToStepDto(this Step stepModel)
        {
            return new StepDto
            {
                Id = stepModel.Id,
                Name = stepModel.Name,
                Description = stepModel.Description
            };
        }
    }
}