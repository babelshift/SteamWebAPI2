using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.GameEconomy
{
    internal class SchemaQualities
    {
        /// <summary>
        /// Normal item rarity: https://wiki.teamfortress.com/wiki/Normal
        /// </summary>
        [JsonProperty("Normal")]
        public uint Normal { get; set; }

        /// <summary>
        /// Genuine item rarity: https://wiki.teamfortress.com/wiki/Genuine
        /// </summary>
        [JsonProperty("rarity1")]
        public uint Rarity1 { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        [JsonProperty("rarity2")]
        public uint Rarity2 { get; set; }

        /// <summary>
        /// Vintage item rarity: https://wiki.teamfortress.com/wiki/Vintage
        /// </summary>
        [JsonProperty("vintage")]
        public uint Vintage { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        [JsonProperty("rarity3")]
        public uint Rarity3 { get; set; }

        /// <summary>
        /// Unusual item rarity: https://wiki.teamfortress.com/wiki/Unusual
        /// </summary>
        [JsonProperty("rarity4")]
        public uint Rarity4 { get; set; }

        /// <summary>
        /// Unique item rarity: https://wiki.teamfortress.com/wiki/Unique
        /// </summary>
        [JsonProperty("Unique")]
        public uint Unique { get; set; }

        /// <summary>
        /// Community item: https://wiki.teamfortress.com/wiki/Community_(quality)
        /// </summary>
        [JsonProperty("community")]
        public uint Community { get; set; }

        /// <summary>
        /// Developer owned item: https://wiki.teamfortress.com/wiki/Valve_(quality)
        /// </summary>
        [JsonProperty("developer")]
        public uint Developer { get; set; }

        /// <summary>
        /// Self made item: https://wiki.teamfortress.com/wiki/Self-Made
        /// </summary>
        [JsonProperty("selfmade")]
        public uint SelfMade { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        [JsonProperty("customized")]
        public uint Customized { get; set; }

        /// <summary>
        /// Strange item: https://wiki.teamfortress.com/wiki/Strange
        /// </summary>
        [JsonProperty("strange")]
        public uint Strange { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        [JsonProperty("completed")]
        public uint Completed { get; set; }

        /// <summary>
        /// Haunted item: https://wiki.teamfortress.com/wiki/Haunted
        /// </summary>
        [JsonProperty("haunted")]
        public uint Haunted { get; set; }

        /// <summary>
        /// Collector's item: https://wiki.teamfortress.com/wiki/Collector%27s
        /// </summary>
        [JsonProperty("collectors")]
        public uint Collectors { get; set; }

        [JsonProperty("paintkitweapon")]
        public uint PaintKitWeapon { get; set; }
    }

    internal class SchemaOriginName
    {
        [JsonProperty("origin")]
        public uint Origin { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    internal class SchemaCapabilities
    {
        [JsonProperty("nameable")]
        public bool Nameable { get; set; }

        [JsonProperty("can_craft_mark")]
        public bool CanCraftMark { get; set; }

        [JsonProperty("can_be_restored")]
        public bool CanBeRestored { get; set; }

        [JsonProperty("strange_parts")]
        public bool StrangeParts { get; set; }

        [JsonProperty("can_card_upgrade")]
        public bool CanCardUpgrade { get; set; }

        [JsonProperty("can_strangify")]
        public bool CanStrangify { get; set; }

        [JsonProperty("can_killstreakify")]
        public bool CanKillstreakify { get; set; }

        [JsonProperty("can_consume")]
        public bool CanConsume { get; set; }

        [JsonProperty("can_gift_wrap")]
        public bool? CanGiftWrap { get; set; }

        [JsonProperty("can_collect")]
        public bool? CanCollect { get; set; }

        [JsonProperty("paintable")]
        public bool? Paintable { get; set; }

        [JsonProperty("can_craft_if_purchased")]
        public bool? CanCraftIfPurchased { get; set; }

        [JsonProperty("can_craft_count")]
        public bool? CanCraftCount { get; set; }

        [JsonProperty("usable_gc")]
        public bool? UsableGc { get; set; }

        [JsonProperty("usable")]
        public bool? Usable { get; set; }

        [JsonProperty("can_customize_texture")]
        public bool? CanCustomizeTexture { get; set; }

        [JsonProperty("usable_out_of_game")]
        public bool? UsableOutOfGame { get; set; }

        [JsonProperty("can_spell_page")]
        public bool? CanSpellPage { get; set; }

        [JsonProperty("duck_upgradable")]
        public bool? DuckUpgradable { get; set; }

        [JsonProperty("decodable")]
        public bool? Decodable { get; set; }
    }

    internal class SchemaAdditionalHiddenBodygroups
    {
        [JsonProperty("hat")]
        public uint Hat { get; set; }

        [JsonProperty("headphones")]
        public uint Headphones { get; set; }

        [JsonProperty("head")]
        public uint? Head { get; set; }
    }

    internal class SchemaStyle
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("additional_hidden_bodygroups")]
        public SchemaAdditionalHiddenBodygroups AdditionalHiddenBodygroups { get; set; }
    }

    internal class SchemaItemAttribute
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }
    }

    internal class SchemaPerClassLoadoutSlots
    {
        [JsonProperty("Soldier")]
        public string Soldier { get; set; }

        [JsonProperty("Heavy")]
        public string Heavy { get; set; }

        [JsonProperty("Pyro")]
        public string Pyro { get; set; }

        [JsonProperty("Engineer")]
        public string Engineer { get; set; }

        [JsonProperty("Demoman")]
        public string Demoman { get; set; }
    }

    internal class SchemaUsageCapabilities
    {
        [JsonProperty("nameable")]
        public bool Nameable { get; set; }

        [JsonProperty("decodable")]
        public bool? Decodable { get; set; }

        [JsonProperty("paintable")]
        public bool? Paintable { get; set; }

        [JsonProperty("can_customize_texture")]
        public bool? CanCustomizeTexture { get; set; }

        [JsonProperty("can_gift_wrap")]
        public bool? CanGiftWrap { get; set; }

        [JsonProperty("paintable_team_colors")]
        public bool? PaintableTeamColors { get; set; }

        [JsonProperty("can_strangify")]
        public bool? CanStrangify { get; set; }

        [JsonProperty("can_killstreakify")]
        public bool? CanKillstreakify { get; set; }

        [JsonProperty("duck_upgradable")]
        public bool? DuckUpgradable { get; set; }

        [JsonProperty("strange_parts")]
        public bool? StrangeParts { get; set; }

        [JsonProperty("can_card_upgrade")]
        public bool? CanCardUpgrade { get; set; }

        [JsonProperty("can_spell_page")]
        public bool? CanSpellPage { get; set; }

        [JsonProperty("can_consume")]
        public bool? CanConsume { get; set; }
    }

    internal class SchemaTool
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("usage_capabilities")]
        public SchemaUsageCapabilities UsageCapabilities { get; set; }

        [JsonProperty("use_string")]
        public string UseString { get; set; }

        [JsonProperty("restriction")]
        public string Restriction { get; set; }
    }

    internal class SchemaItem
    {
        [JsonProperty("defindex")]
        public uint DefIndex { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("item_type_name")]
        public string ItemTypeName { get; set; }

        [JsonProperty("item_name")]
        public string ItemName { get; set; }

        [JsonProperty("item_description")]
        public string ItemDescription { get; set; }

        [JsonProperty("image_inventory")]
        public string ImageInventoryPath { get; set; }

        [JsonProperty("item_class")]
        public string ItemClass { get; set; }
        
        [JsonProperty("proper_name")]
        public bool ProperName { get; set; }

        [JsonProperty("item_slot")]
        public string ItemSlot { get; set; }

        [JsonProperty("model_player")]
        public string ModelPlayer { get; set; }

        [JsonProperty("item_quality")]
        public uint ItemQuality { get; set; }

        [JsonProperty("min_ilevel")]
        public uint MinIlevel { get; set; }

        [JsonProperty("max_ilevel")]
        public uint MaxIlevel { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("image_url_large")]
        public string ImageUrlLarge { get; set; }

        [JsonProperty("craft_class")]
        public string CraftClass { get; set; }

        [JsonProperty("craft_material_type")]
        public string CraftMaterialType { get; set; }

        [JsonProperty("item_logname")]
        public string ItemLogName { get; set; }

        [JsonProperty("capabilities")]
        public SchemaCapabilities Capabilities { get; set; }

        [JsonProperty("used_by_classes")]
        public IList<string> UsedByClasses { get; set; }

        [JsonProperty("styles")]
        public IList<SchemaStyle> Styles { get; set; }

        [JsonProperty("attributes")]
        public IList<SchemaItemAttribute> Attributes { get; set; }

        [JsonProperty("drop_type")]
        public string DropType { get; set; }

        [JsonProperty("item_set")]
        public string ItemSet { get; set; }

        [JsonProperty("holiday_restriction")]
        public string HolidayRestriction { get; set; }

        [JsonProperty("per_class_loadout_slots")]
        public SchemaPerClassLoadoutSlots PerClassLoadoutSlots { get; set; }

        [JsonProperty("tool")]
        public SchemaTool Tool { get; set; }
    }

    internal class SchemaAttribute
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("defindex")]
        public uint Defindex { get; set; }

        [JsonProperty("attribute_class")]
        public string AttributeClass { get; set; }

        [JsonProperty("description_string")]
        public string DescriptionString { get; set; }

        [JsonProperty("description_format")]
        public string DescriptionFormat { get; set; }

        [JsonProperty("effect_type")]
        public string EffectType { get; set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("stored_as_integer")]
        public bool StoredAsInteger { get; set; }
    }

    internal class SchemaItemSetAttribute
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }
    }

    internal class SchemaItemSet
    {
        [JsonProperty("item_set")]
        public string ItemSet { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("items")]
        public IList<string> Items { get; set; }

        [JsonProperty("attributes")]
        public IList<SchemaItemSetAttribute> Attributes { get; set; }

        [JsonProperty("store_bundle")]
        public string StoreBundleName { get; set; }
    }

    internal class SchemaAttributeControlledAttachedParticle
    {
        [JsonProperty("system")]
        public string System { get; set; }

        [JsonProperty("id")]
        public uint Id { get; set; }

        [JsonProperty("attach_to_rootbone")]
        public bool AttachToRootbone { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("attachment")]
        public string Attachment { get; set; }
    }

    internal class SchemaLevel
    {
        [JsonProperty("level")]
        public uint Level { get; set; }

        [JsonProperty("required_score")]
        public uint RequiredScore { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    internal class SchemaItemLevel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("levels")]
        public IList<SchemaLevel> Levels { get; set; }
    }

    internal class SchemaKillEaterScoreType
    {
        [JsonProperty("type")]
        public uint Type { get; set; }

        [JsonProperty("type_name")]
        public string TypeName { get; set; }

        [JsonProperty("level_data")]
        public string LevelData { get; set; }
    }

    internal class SchemaString
    {
        [JsonProperty("index")]
        public uint Index { get; set; }

        [JsonProperty("string")]
        public string String { get; set; }
    }

    internal class SchemaStringLookup
    {
        [JsonProperty("table_name")]
        public string TableName { get; set; }

        [JsonProperty("strings")]
        public IList<SchemaString> Strings { get; set; }
    }

    internal class SchemaResult
    {
        [JsonProperty("status")]
        public uint Status { get; set; }

        [JsonProperty("items_game_url")]
        public string ItemsGameUrl { get; set; }

        [JsonProperty("qualities")]
        public SchemaQualities Qualities { get; set; }

        [JsonProperty("originNames")]
        public IList<SchemaOriginName> OriginNames { get; set; }

        [JsonProperty("items")]
        public IList<SchemaItem> Items { get; set; }

        [JsonProperty("attributes")]
        public IList<SchemaAttribute> Attributes { get; set; }

        [JsonProperty("item_sets")]
        public IList<SchemaItemSet> ItemSets { get; set; }

        [JsonProperty("attribute_controlled_attached_particles")]
        public IList<SchemaAttributeControlledAttachedParticle> AttributeControlledAttachedParticles { get; set; }

        [JsonProperty("item_levels")]
        public IList<SchemaItemLevel> ItemLevels { get; set; }

        [JsonProperty("kill_eater_score_types")]
        public IList<SchemaKillEaterScoreType> KillEaterScoreTypes { get; set; }

        [JsonProperty("string_lookups")]
        public IList<SchemaStringLookup> StringLookups { get; set; }
    }

    internal class SchemaResultContainer
    {
        [JsonProperty("result")]
        public SchemaResult Result { get; set; }
    }
}