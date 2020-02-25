namespace Steam.Models.DOTA2
{
    public class LiveLeagueGamePlayerInfoModel
    {
        public uint AccountId { get; set; }

        public string Name { get; set; }

        public uint HeroId { get; set; }

        public uint Team { get; set; }
    }
}