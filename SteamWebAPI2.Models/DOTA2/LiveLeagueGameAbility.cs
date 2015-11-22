using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models.DOTA2
{
    public class LiveLeagueGameAbility
    {
        [JsonProperty(PropertyName = "ability_id")]
        public int AbilityId { get; set; }
        [JsonProperty(PropertyName = "ability_level")]
        public int AbilityLevel { get; set; }
    }
}
