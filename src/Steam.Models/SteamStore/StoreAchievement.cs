namespace Steam.Models.SteamStore
{
    public class StoreAchievement
    {
        public uint Total { get; set; }

        public StoreHighlighted[] Highlighted { get; set; }
    }
}