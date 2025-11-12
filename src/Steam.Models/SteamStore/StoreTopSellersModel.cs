namespace Steam.Models.SteamStore
{
    public class StoreTopSellersModel
    {
        public uint Id { get; set; }

        public string Name { get; set; }

        public StoreItemModel[] Items { get; set; }
    }
}
