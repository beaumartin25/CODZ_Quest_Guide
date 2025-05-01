using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Map;
using api.Models;

namespace api.Mappers
{
    public static class MapMappers
    {
        public static MapDto ToMapDto(this Map mapModel)
        {
            return new MapDto
            {
                Id = mapModel.Id,
                Name = mapModel.Name,
                ImageUrl = mapModel.ImageUrl
            };
        }

        public static Map ToMapFromCreateDto(this CreateMapRequestDto mapDto)
        {
            return new Map
            {
                Name = mapDto.Name,
                ImageUrl = mapDto.ImageUrl
            };
        }
    }
}