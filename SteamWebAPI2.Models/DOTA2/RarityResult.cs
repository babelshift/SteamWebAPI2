using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models.DOTA2
{
    public class RarityResult
    {
        public int Count { get; set; }
        public int Status { get; set; }
        public IList<Rarity> Rarities { get; set; }
    }
}
