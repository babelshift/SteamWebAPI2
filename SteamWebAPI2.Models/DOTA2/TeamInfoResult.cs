using Newtonsoft.Json;
using SteamWebAPI2.Models.Utilities;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.DOTA2
{
    public class TeamInfoResult
    {
        public int Status { get; set; }

        [JsonConverter(typeof(TeamInfoJsonConverter))]
        public IList<TeamInfo> Teams { get; set; }
    }
}