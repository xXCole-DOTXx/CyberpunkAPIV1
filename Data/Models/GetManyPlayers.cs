using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberpunkAPI.Data.Models
{
    public class GetManyPlayers
    {
        public int ID { get; set; }
        public string Handle { get; set; }
        public string Role { get; set; }
        public string Avatar { get; set; }
    }
}
