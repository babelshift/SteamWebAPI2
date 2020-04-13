using System;

namespace Steam.Models.CSGO
{
    public class GameMapsPlaytimeModel
    {
        public DateTime IntervalStartTimeStamp { get; set; }
        public string MapName { get; set; }
        public float RelativePercentage { get; set; }
    }
}