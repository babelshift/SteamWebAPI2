using System.Collections.Generic;

namespace Steam.Models.DOTA2
{
    public class ItemAbilitySchemaItemModel
    {
        public uint Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Valve's source files don't include localized names. Instead, the callers are responsibel for populating this value
        /// by performing a lookup in the various language/token mapping files.
        /// </summary>
        public string LocalizedName { get; set; }

        public string AbilityBehavior { get; set; }

        public string AbilityCastRange { get; set; }

        public string AbilityCastPoint { get; set; }

        public string AbilityChannelTime { get; set; }

        public string AbilityCooldown { get; set; }

        public string AbilityDuration { get; set; }

        public string AbilitySharedCooldown { get; set; }

        public string AbilityDamage { get; set; }

        public string AbilityManaCost { get; set; }

        public double AbilityModifierSupportValue { get; set; }

        public string AbilityUnitTargetTeam { get; set; }

        public string AbilityUnitDamageType { get; set; }

        public string AbilityUnitTargetFlags { get; set; }

        public string AbilityUnitTargetType { get; set; }

        public IList<AbilitySpecialSchemaItemModel> AbilitySpecials { get; set; }

        public uint ItemCost { get; set; }

        public string ItemShopTags { get; set; }

        public string ItemQuality { get; set; }

        public bool ItemStackable { get; set; }

        public string ItemShareability { get; set; }

        public bool ItemPermanent { get; set; }

        public uint? ItemInitialCharges { get; set; }

        public uint? ItemDisplayCharges { get; set; }

        public uint? ItemStockMax { get; set; }

        public uint? ItemStockInitial { get; set; }

        public double? ItemStockTime { get; set; }

        public bool? ItemPurchasable { get; set; }

        public bool? ItemSellable { get; set; }

        public bool? ItemKillable { get; set; }

        public string ItemDeclarations { get; set; }

        public bool? ItemCastOnPickup { get; set; }

        public bool? ItemSupport { get; set; }

        public string ItemResult { get; set; }

        public bool? ItemAlertable { get; set; }

        public bool? ItemDroppable { get; set; }

        public bool? ItemContributesToNetWorthWhenDropped { get; set; }

        public string ItemDisassembleRule { get; set; }
    }
}