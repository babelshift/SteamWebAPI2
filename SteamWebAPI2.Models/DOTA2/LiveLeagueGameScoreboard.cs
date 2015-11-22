using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models.DOTA2
{
    public class LiveLeagueGameScoreboard
    {
        public double Duration { get; set; }
        [JsonProperty(PropertyName = "roshan_respawn_timer")]
        public int RoshanRespawnTimer { get; set; }
        public LiveLeagueGameTeamRadiantDetail Radiant { get; set; }
        public LiveLeagueGameTeamDireDetail Dire { get; set; }
    }
}
