using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Map
{
    public class MapDto
    {
        public int Id { get; set; }
        public string MapName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}