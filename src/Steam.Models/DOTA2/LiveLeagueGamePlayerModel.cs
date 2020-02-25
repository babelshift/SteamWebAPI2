namespace Steam.Models.DOTA2
{
    public class LiveLeagueGamePlayerModel
    {
        public uint AccountId { get; set; }
        public string Name { get; set; }
        public uint HeroId { get; set; }
        public string HeroName { get; set; }
        public string HeroAvatarImageFilePath { get; set; }
        public uint Team { get; set; }
        public uint KillCount { get; set; }
        public uint DeathCount { get; set; }
        public uint AssistCount { get; set; }
        public double PositionX { get; set; }
        public double PositionY { get; set; }
        public string HeroUrl { get; set; }
        public LiveLeagueGameItemModel Item0 { get; set; }
        public LiveLeagueGameItemModel Item1 { get; set; }
        public LiveLeagueGameItemModel Item2 { get; set; }
        public LiveLeagueGameItemModel Item3 { get; set; }
        public LiveLeagueGameItemModel Item4 { get; set; }
        public LiveLeagueGameItemModel Item5 { get; set; }
        public uint RespawnTimer { get; set; }
        public uint NetWorth { get; set; }
        public uint Gold { get; set; }
        public uint Level { get; set; }
        public uint LastHits { get; set; }
        public uint Denies { get; set; }
        public uint GoldPerMinute { get; set; }
        public uint XpPerMinute { get; set; }
        public uint UltimateState { get; set; }
        public uint UltimateCooldown { get; set; }
    }
}