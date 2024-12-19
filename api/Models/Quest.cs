using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Quest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool MainQuest { get; set; }
        public int? MapId { get; set; }
        public Map? Map { get; set; }
        public List<Step> Steps { get; set; } = new List<Step>();
    }
}