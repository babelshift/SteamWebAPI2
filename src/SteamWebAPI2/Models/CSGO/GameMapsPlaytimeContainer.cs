using System.Collections.Generic;
using Newtonsoft.Json;
using SteamWebAPI2.Utilities.JsonConverters;

namespace SteamWebAPI2.Models.CSGO
{
    public class GameMapsPlaytime
    {
        public ulong IntervalStartTimeStamp { get; set; }
        public string MapName { get; set; }
        public float RelativePercentage { get; set; }
    }

    public class GameMapsPlaytimeResult
    {
        public IEnumerable<GameMapsPlaytime> Playtimes { get; set; }
    }

    public class GameMapsPlaytimeContainer
    {
        [JsonConverter(typeof(GameMapsPlaytimeConverter))]
        public GameMapsPlaytimeResult Result { get; set; }
    }
}