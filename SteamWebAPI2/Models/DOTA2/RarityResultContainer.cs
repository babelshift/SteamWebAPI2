using System.Collections.Generic;

namespace SteamWebAPI2.Models.DOTA2
{
    public class Rarity
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Order { get; set; }
        public string Color { get; set; }
    }

    public class RarityResult
    {
        public int Count { get; set; }
        public int Status { get; set; }
        public IList<Rarity> Rarities { get; set; }
    }

    internal class RarityResultContainer
    {
        public RarityResult Result { get; set; }
    }
}