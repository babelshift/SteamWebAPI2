using System.Collections.Generic;

namespace Steam.Models.SteamEconomy
{
    public class AssetPriceResultModel
    {
        public bool Success { get; set; }

        public IReadOnlyCollection<AssetModel> Assets { get; set; }

        public AssetTagsModel Tags { get; set; }

        public AssetTagIdsModel TagIds { get; set; }
    }
}