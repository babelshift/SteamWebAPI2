using Newtonsoft.Json;
using SteamWebAPI2.Models.Utilities;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.CSGO
{
    public class ServerStatusApp
    {
        public int Version { get; set; }
        public long Timestamp { get; set; }
        public string Time { get; set; }
    }

    public class ServerStatusDatacenter
    {
        public string Name { get; set; }
        public string Capacity { get; set; }
        public string Load { get; set; }
    }

    public class ServerStatusMatchmaking
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

    public class ServerStatusServices
    {
        public string SessionsLogon { get; set; }
        public string SteamCommunity { get; set; }
        public string IEconItems { get; set; }
        public string Leaderboards { get; set; }
    }

    public class ServerStatusResult
    {
        public ServerStatusApp App { get; set; }
        public ServerStatusServices Services { get; set; }

        /// <summary>
        /// We have to use a custom converter here because the JSON response for data centers is badly formatted. Instead of using a JSON array in which
        /// all data centers are listed, Valve decided to make individual objects for each data center. So we fix that by parsing them into an array.
        /// </summary>
        [JsonConverter(typeof(CSGODataCenterJsonConverter))]
        public IList<ServerStatusDatacenter> Datacenters { get; set; }

        public ServerStatusMatchmaking Matchmaking { get; set; }
    }

    public class ServerStatusResultContainer
    {
        public ServerStatusResult Result { get; set; }
    }
}