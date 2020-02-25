using Steam.Models.DOTA2;
using System;
using System.Collections.Generic;

namespace Steam.Models.GameEconomy
{
    public class SchemaItemModel
    {
        public uint DefIndex { get; set; }

        public string Name { get; set; }
        
        public string ImageInventoryPath { get; set; }

        public string ItemName { get; set; }

        public string ItemDescription { get; set; }
        
        public string ItemTypeName { get; set; }

        public string ItemClass { get; set; }
        
        public bool ProperName { get; set; }

        public string ItemSlot { get; set; }

        public string ModelPlayer { get; set; }

        public uint ItemQuality { get; set; }
        
        public uint MinIlevel { get; set; }

        public uint MaxIlevel { get; set; }

        public string ImageUrl { get; set; }

        public string ImageUrlLarge { get; set; }

        public string CraftClass { get; set; }

        public string CraftMaterialType { get; set; }

        public string ItemLogName { get; set; }

        public SchemaCapabilitiesModel Capabilities { get; set; }

        public IReadOnlyCollection<string> UsedByClasses { get; set; }

        public IReadOnlyCollection<SchemaStyleModel> Styles { get; set; }
        
        public IReadOnlyCollection<SchemaItemAttributeModel> Attributes { get; set; }

        public string DropType { get; set; }

        public string ItemSet { get; set; }

        public string HolidayRestriction { get; set; }

        public SchemaPerClassLoadoutSlotsModel PerClassLoadoutSlots { get; set; }

        public SchemaToolModel Tool { get; set; }

        public string Prefab { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public string TournamentUrl { get; set; }

        public string ImageBannerPath { get; set; }

        public string ItemRarity { get; set; }

        public SchemaItemPriceInfoModel PriceInfo { get; set; }

        public IList<string> UsedByHeroes { get; set; }

        public IList<string> BundledItems { get; set; }
    }
}