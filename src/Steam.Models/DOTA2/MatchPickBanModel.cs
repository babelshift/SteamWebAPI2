namespace Steam.Models.DOTA2
{
    public class MatchPickBanModel
    {
        public bool IsPick { get; set; }

        public uint HeroId { get; set; }

        public uint Team { get; set; }
        public uint Order { get; set; }
    }
}