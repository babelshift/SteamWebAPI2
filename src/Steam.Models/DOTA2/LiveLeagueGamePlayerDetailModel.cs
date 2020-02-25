namespace Steam.Models.DOTA2
{
    public class LiveLeagueGamePlayerDetailModel
    {
        public uint PlayerSlot { get; set; }
        public uint AccountId { get; set; }
        public uint HeroId { get; set; }
        public uint Kills { get; set; }
        public uint Deaths { get; set; }
        public uint Assists { get; set; }
        public uint LastHits { get; set; }
        public uint Denies { get; set; }
        public uint Gold { get; set; }
        public uint Level { get; set; }
        public uint GoldPerMinute { get; set; }
        public uint ExperiencePerMinute { get; set; }
        public uint UltimateState { get; set; }
        public uint UltimateCooldown { get; set; }
        public uint Item0 { get; set; }
        public uint Item1 { get; set; }
        public uint Item2 { get; set; }
        public uint Item3 { get; set; }
        public uint Item4 { get; set; }
        public uint Item5 { get; set; }
        public uint RespawnTimer { get; set; }
        public double PositionX { get; set; }
        public double PositionY { get; set; }
        public uint NetWorth { get; set; }
    }
}