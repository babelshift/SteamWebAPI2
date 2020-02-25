using System.Collections.Generic;

namespace Steam.Models.SteamEconomy
{
    public class AssetClassInfoResultModel
    {
        public IReadOnlyCollection<AssetClassInfoModel> AssetClasses { get; set; }

        public bool Success { get; set; }
    }
}