using System;
using System.Collections.Generic;

namespace Steam.Models.DOTA2
{
    public class SchemaItemModel
    {
        public string DefIndex { get; set; }

        public string Name { get; set; }

        public string ImageInventoryPath { get; set; }

        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public string ItemTypeName { get; set; }

        public string Prefab { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public SchemaItemToolModel Tool { get; set; }

        public string TournamentUrl { get; set; }

        public string ImageBannerPath { get; set; }

        public string ItemRarity { get; set; }

        public string ItemQuality { get; set; }

        public string ItemSlot { get; set; }

        public SchemaItemPriceInfoModel PriceInfo { get; set; }

        public IList<string> UsedByHeroes { get; set; }

        public IList<string> BundledItems { get; set; }
    }
}