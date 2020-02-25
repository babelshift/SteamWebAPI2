namespace Steam.Models.SteamStore
{
    public class StorePriceOverview
    {
        public string Currency { get; set; }

        public uint Initial { get; set; }

        public uint Final { get; set; }

        public uint DiscountPercent { get; set; }

        public string InitialFormatted { get; set; }

        public string FinalFormatted { get; set; }
    }
}
