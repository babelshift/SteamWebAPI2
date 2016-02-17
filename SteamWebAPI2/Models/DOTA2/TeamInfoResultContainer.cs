using Newtonsoft.Json;
using SteamWebAPI2.Utilities.JsonConverters;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.DOTA2
{
    internal class TeamInfo
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public long TimeCreated { get; set; }
        public string Rating { get; set; }
        public long Logo { get; set; }
        public long LogoSponsor { get; set; }
        public string CountryCode { get; set; }
        public string Url { get; set; }
        public int GamesPlayedWithCurrentRoster { get; set; }
        public uint AdminAccountId { get; set; }
        public IList<int> PlayerIds { get; set; }
        public IList<int> LeagueIds { get; set; }
    }

    internal class TeamInfoResult
    {
        public int Status { get; set; }

        [JsonConverter(typeof(TeamInfoJsonConverter))]
        public IList<TeamInfo> Teams { get; set; }
    }

    internal class TeamInfoResultContainer
    {
        public TeamInfoResult Result { get; set; }
    }
}