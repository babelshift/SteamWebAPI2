using Newtonsoft.Json;
using SteamWebAPI2.Utilities.JsonConverters;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.DOTA2
{
    internal class TeamInfo
    {
        public uint TeamId { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public ulong TimeCreated { get; set; }
        public string Rating { get; set; }
        public ulong Logo { get; set; }
        public ulong LogoSponsor { get; set; }
        public string CountryCode { get; set; }
        public string Url { get; set; }
        public uint GamesPlayedWithCurrentRoster { get; set; }
        public uint AdminAccountId { get; set; }
        public IList<uint> PlayerIds { get; set; }
        public IList<uint> LeagueIds { get; set; }
    }

    internal class TeamInfoResult
    {
        public uint Status { get; set; }

        [JsonConverter(typeof(TeamInfoJsonConverter))]
        public IList<TeamInfo> Teams { get; set; }
    }

    internal class TeamInfoResultContainer
    {
        public TeamInfoResult Result { get; set; }
    }
}