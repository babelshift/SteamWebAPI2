using System.Collections.Generic;

namespace Steam.Models.SteamEconomy
{
    public class AssetModel
    {
        public AssetPricesModel Prices { get; set; }

        public string Name { get; set; }

        public string Date { get; set; }

        public IReadOnlyCollection<AssetClassModel> Class { get; set; }

        public ulong ClassId { get; set; }

        public IReadOnlyCollection<string> Tags { get; set; }

        public IReadOnlyCollection<long> TagIds { get; set; }
    }
}