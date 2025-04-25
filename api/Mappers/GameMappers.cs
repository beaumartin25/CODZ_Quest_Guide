using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Game;
using api.Models;

namespace api.Mappers
{
    public static class GameMappers
    {
        public static GameDto ToGameDto(this Game gameModel)
        {
            return new GameDto
            {
                Id = gameModel.Id,
                Name = gameModel.Name,
                ImageUrl = gameModel.ImageUrl
            };
        }

        public static Game ToGameFromCreateDto(this CreateGameRequestDto gameDto)
        {
            return new Game
            {
                Name = gameDto.Name,
                ImageUrl = gameDto.ImageUrl
            };
        }
    }
}