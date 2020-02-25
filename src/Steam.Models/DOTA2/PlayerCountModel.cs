namespace Steam.Models.DOTA2
{
    public class PlayerCountModel
    {
        public uint InGamePlayerCount { get; set; }
        public uint DailyPeakPlayerCount { get; set; }
        public uint AllTimePeakPlayerCount { get; set; }
    }
}