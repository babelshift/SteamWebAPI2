using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models.DOTA2
{
    public class LiveLeagueGameTeamDireDetail
    {
        public int Score { get; set; }
        [JsonProperty(PropertyName = "tower_state")]
        public int TowerState { get; set; }
        [JsonProperty(PropertyName = "barracks_state")]
        public int BarracksState { get; set; }
        public IList<LiveLeagueGamePick> Picks { get; set; }
        public IList<LiveLeagueGameBan> Bans { get; set; }
        public IList<LiveLeagueGamePlayerDetail> Players { get; set; }
        public IList<LiveLeagueGameAbility> Abilities { get; set; }
    }
}
