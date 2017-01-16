using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.DOTA2
{
    internal class LeagueResult
    {
        public IList<League> Leagues { get; set; }
    }

    internal class League
    {
        public string Name { get; set; }
        public uint LeagueId { get; set; }
        public string Description { get; set; }

        [JsonProperty(PropertyName = "tournament_url")]
        public string TournamentUrl { get; set; }

        public uint ItemDef { get; set; }
    }

    internal class LeagueResultContainer
    {
        public LeagueResult Result { get; set; }
    }
}