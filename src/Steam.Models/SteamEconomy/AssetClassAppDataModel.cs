using System.Collections.Generic;

namespace Steam.Models.SteamEconomy
{
    public class AssetClassAppDataModel
    {
        public uint DefIndex { get; set; }

        public uint Quality { get; set; }

        public uint Slot { get; set; }

        public IReadOnlyCollection<AssetClassAppDataFilterModel> FilterData { get; set; }

        public IReadOnlyCollection<long> PlayerClassIds { get; set; }

        public string HighlightColor { get; set; }
    }
}