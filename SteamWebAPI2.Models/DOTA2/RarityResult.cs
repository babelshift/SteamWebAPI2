using System.Collections.Generic;

namespace SteamWebAPI2.Models.DOTA2
{
    public class RarityResult
    {
        public int Count { get; set; }
        public int Status { get; set; }
        public IList<Rarity> Rarities { get; set; }
    }
}