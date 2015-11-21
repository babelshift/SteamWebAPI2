using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models.DOTA2
{
    public class ProPlayerListResult
    {
        [JsonProperty(PropertyName = "player_infos")]
        public IList<ProPlayerInfo> PlayerInfos { get; set; }
        public IList<ProPlayerLeaderboard> Leaderboards { get; set; }
    }
}
