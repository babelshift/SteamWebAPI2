using System.Collections.Generic;

namespace SteamWebAPI2.Models.DOTA2
{
    public class Hero
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }

    public class HeroResult
    {
        public IList<Hero> Heroes { get; set; }
    }

    public class HeroResultContainer
    {
        public HeroResult Result { get; set; }
    }
}