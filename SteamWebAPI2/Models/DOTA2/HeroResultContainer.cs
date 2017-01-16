using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.DOTA2
{
    internal class Hero
    {
        public string Name { get; set; }
        public uint Id { get; set; }
        
        [JsonProperty(PropertyName = "localized_name")]
        public string LocalizedName { get; set; }
    }

    internal class HeroResult
    {
        public IList<Hero> Heroes { get; set; }
    }

    internal class HeroResultContainer
    {
        public HeroResult Result { get; set; }
    }
}