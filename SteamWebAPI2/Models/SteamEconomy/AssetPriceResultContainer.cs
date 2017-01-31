using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.SteamEconomy
{
    internal class AssetPrices
    {
        [JsonProperty("USD")]
        public uint USD { get; set; }

        [JsonProperty("GBP")]
        public uint GBP { get; set; }

        [JsonProperty("EUR")]
        public uint EUR { get; set; }

        [JsonProperty("RUB")]
        public uint RUB { get; set; }

        [JsonProperty("BRL")]
        public uint BRL { get; set; }

        [JsonProperty("JPY")]
        public uint JPY { get; set; }

        [JsonProperty("NOK")]
        public uint NOK { get; set; }

        [JsonProperty("IDR")]
        public uint IDR { get; set; }

        [JsonProperty("MYR")]
        public uint MYR { get; set; }

        [JsonProperty("PHP")]
        public uint PHP { get; set; }

        [JsonProperty("SGD")]
        public uint SGD { get; set; }

        [JsonProperty("THB")]
        public uint THB { get; set; }

        [JsonProperty("VND")]
        public uint VND { get; set; }

        [JsonProperty("KRW")]
        public uint KRW { get; set; }

        [JsonProperty("TRY")]
        public uint TRY { get; set; }

        [JsonProperty("UAH")]
        public uint UAH { get; set; }

        [JsonProperty("MXN")]
        public uint MXN { get; set; }

        [JsonProperty("CAD")]
        public uint CAD { get; set; }

        [JsonProperty("AUD")]
        public uint AUD { get; set; }

        [JsonProperty("NZD")]
        public uint NZD { get; set; }

        [JsonProperty("CNY")]
        public uint CNY { get; set; }

        [JsonProperty("TWD")]
        public uint TWD { get; set; }

        [JsonProperty("HKD")]
        public uint HKD { get; set; }

        [JsonProperty("INR")]
        public uint INR { get; set; }

        [JsonProperty("AED")]
        public uint AED { get; set; }

        [JsonProperty("SAR")]
        public uint SAR { get; set; }

        [JsonProperty("ZAR")]
        public uint ZAR { get; set; }
    }

    internal class AssetClass
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    internal class Asset
    {
        [JsonProperty("prices")]
        public AssetPrices Prices { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("class")]
        public IList<AssetClass> Class { get; set; }

        [JsonProperty("classid")]
        public ulong ClassId { get; set; }

        [JsonProperty("tags")]
        public IList<string> Tags { get; set; }

        [JsonProperty("tag_ids")]
        public IList<long> TagIds { get; set; }
    }

    internal class AssetTags
    {
        [JsonProperty("Cosmetics")]
        public string Cosmetics { get; set; }

        [JsonProperty("Tools")]
        public string Tools { get; set; }

        [JsonProperty("Weapons")]
        public string Weapons { get; set; }

        [JsonProperty("Taunts")]
        public string Taunts { get; set; }

        [JsonProperty("Bundles")]
        public string Bundles { get; set; }

        [JsonProperty("Limited")]
        public string Limited { get; set; }

        [JsonProperty("New")]
        public string New { get; set; }

        [JsonProperty("Maps")]
        public string Maps { get; set; }

        [JsonProperty("Halloween")]
        public string Halloween { get; set; }
    }

    internal class AssetTagIds
    {
        [JsonProperty("0")]
        public ulong Tag0 { get; set; }

        [JsonProperty("1")]
        public ulong Tag1 { get; set; }

        [JsonProperty("2")]
        public ulong Tag2 { get; set; }

        [JsonProperty("3")]
        public ulong Tag3 { get; set; }

        [JsonProperty("4")]
        public ulong Tag4 { get; set; }

        [JsonProperty("5")]
        public ulong Tag5 { get; set; }

        [JsonProperty("6")]
        public ulong Tag6 { get; set; }

        [JsonProperty("7")]
        public ulong Tag7 { get; set; }

        [JsonProperty("8")]
        public ulong Tag8 { get; set; }
    }

    internal class AssetPriceResult
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("assets")]
        public IList<Asset> Assets { get; set; }

        [JsonProperty("tags")]
        public AssetTags Tags { get; set; }

        [JsonProperty("tag_ids")]
        public AssetTagIds TagIds { get; set; }
    }

    internal class AssetPriceResultContainer
    {
        [JsonProperty("result")]
        public AssetPriceResult Result { get; set; }
    }
}