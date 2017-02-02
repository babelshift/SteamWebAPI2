using Newtonsoft.Json;
using SteamWebAPI2.Utilities.JsonConverters;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.SteamEconomy
{
    internal class AssetClassDescription
    {
        public string Type { get; set; }

        public string Value { get; set; }

        public string Color { get; set; }

        public string AppData { get; set; }
    }

    internal class AssetClassAction
    {
        public string Name { get; set; }

        public string Link { get; set; }
    }

    internal class AssetClassMarketAction
    {
        public string Name { get; set; }

        public string Link { get; set; }
    }

    internal class AssetClassTag
    {
        public string InternalName { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string Color { get; set; }

        public string CategoryName { get; set; }
    }

    internal class AssetClassAppDataFilter
    {
        public IList<long> ElementIds { get; set; }
    }

    internal class AssetClassAppData
    {
        public uint DefIndex { get; set; }

        public string Quality { get; set; }

        public string Slot { get; set; }

        public IList<AssetClassAppDataFilter> FilterData { get; set; }

        public IList<ulong> PlayerClassIds { get; set; }

        public string HighlightColor { get; set; }
    }

    internal class AssetClassInfo
    {
        public string IconUrl { get; set; }

        public string IconUrlLarge { get; set; }

        public string IconDragUrl { get; set; }

        public string Name { get; set; }

        public string MarketHashName { get; set; }

        public string MarketName { get; set; }

        public string NameColor { get; set; }

        public string BackgroundColor { get; set; }

        public string Type { get; set; }

        public string Tradable { get; set; }

        public string Marketable { get; set; }

        public string Commodity { get; set; }

        public string MarketTradableRestriction { get; set; }

        public string MarketMarketableRestriction { get; set; }

        public string FraudWarnings { get; set; }

        public IList<AssetClassDescription> Descriptions { get; set; }

        public IList<AssetClassAction> Actions { get; set; }

        public IList<AssetClassMarketAction> MarketActions { get; set; }

        public IList<AssetClassTag> Tags { get; set; }

        public AssetClassAppData AppData { get; set; }

        public ulong ClassId { get; set; }
    }

    internal class AssetClassInfoResult
    {
        public IList<AssetClassInfo> AssetClasses { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }
    }

    internal class AssetClassInfoResultContainer
    {
        [JsonProperty("result")]
        [JsonConverter(typeof(AssetClassInfoJsonConverter))]
        public AssetClassInfoResult Result { get; set; }
    }
}