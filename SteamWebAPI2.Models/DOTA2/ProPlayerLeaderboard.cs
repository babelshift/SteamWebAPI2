using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.DOTA2
{
    public class ProPlayerLeaderboard
    {
        public int Division { get; set; }

        [JsonProperty(PropertyName = "account_ids")]
        public IList<int> AccountIds { get; set; }
    }
}