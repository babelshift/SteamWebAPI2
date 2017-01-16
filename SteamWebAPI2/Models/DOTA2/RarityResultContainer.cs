using System.Collections.Generic;

namespace SteamWebAPI2.Models.DOTA2
{
    internal class Rarity
    {
        public string Name { get; set; }
        public uint Id { get; set; }
        public uint Order { get; set; }
        public string Color { get; set; }
        public string LocalizedName { get; set; }
    }

    internal class RarityResult
    {
        public uint Count { get; set; }
        public uint Status { get; set; }
        public IList<Rarity> Rarities { get; set; }
    }

    internal class RarityResultContainer
    {
        public RarityResult Result { get; set; }
    }
}