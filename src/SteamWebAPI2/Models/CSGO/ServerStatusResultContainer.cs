using Newtonsoft.Json;
using SteamWebAPI2.Utilities.JsonConverters;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.CSGO
{
    internal class ServerStatusApp
    {
        public uint Version { get; set; }
        public ulong Timestamp { get; set; }
        public string Time { get; set; }
    }

    internal class ServerStatusDatacenter
    {
        public string Name { get; set; }
        public string Capacity { get; set; }
        public string Load { get; set; }
    }

    internal class ServerStatusMatchmaking
    {
        public string Scheduler { get; set; }

        [JsonProperty(PropertyName = "online_servers")]
        public uint OnlineServers { get; set; }

        [JsonProperty(PropertyName = "online_players")]
        public uint OnlinePlayers { get; set; }

        [JsonProperty(PropertyName = "searching_players")]
        public uint SearchingPlayers { get; set; }

        [JsonProperty(PropertyName = "search_seconds_avg")]
        public uint SearchSecondsAverage { get; set; }
    }

    internal class ServerStatusServices
    {
        public string SessionsLogon { get; set; }
        public string SteamCommunity { get; set; }
        public string IEconItems { get; set; }
        public string Leaderboards { get; set; }
    }

    internal class ServerStatusResult
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

    internal class ServerStatusResultContainer
    {
        public ServerStatusResult Result { get; set; }
    }
}