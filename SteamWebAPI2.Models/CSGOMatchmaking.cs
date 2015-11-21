using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models
{
    public class CSGOMatchmaking
    {
        public string Scheduler { get; set; }

        [JsonProperty(PropertyName = "online_servers")]
        public int OnlineServers { get; set; }

        [JsonProperty(PropertyName = "online_players")]
        public int OnlinePlayers { get; set; }

        [JsonProperty(PropertyName = "searching_players")]
        public int SearchingPlayers { get; set; }

        [JsonProperty(PropertyName = "search_seconds_avg")]
        public int SearchSecondsAverage { get; set; }
    }
}
