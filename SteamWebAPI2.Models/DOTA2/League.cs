using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models.DOTA2
{
    public class League
    {
        public string Name { get; set; }
        public int LeagueId { get; set; }
        public string Description { get; set; }
        [JsonProperty(PropertyName = "tournament_url")]
        public string TournamentUrl { get; set; }
        public int ItemDef { get; set; }
    }
}
