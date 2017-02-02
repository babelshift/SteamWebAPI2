using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.GameEconomy
{
    internal class EconItemResultContainer
    {
        public EconItemResult Result { get; set; }
    }

    internal class EconItemResult
    {
        public uint Status { get; set; }

        [JsonProperty(PropertyName = "num_backpack_slots")]
        public uint NumBackpackSlots { get; set; }

        public IList<EconItem> Items { get; set; }
    }

    internal class EconItemEquipped
    {
        [JsonProperty(PropertyName = "class")]
        public uint ClassId { get; set; }

        public uint Slot { get; set; }
    }

    internal class EconItemAttributeAccountInfo
    {
        public ulong SteamId { get; set; }
        public string PersonaName { get; set; }
    }

    internal class EconItemAttribute
    {
        public uint DefIndex { get; set; }
        public object Value { get; set; }

        [JsonProperty(PropertyName = "float_value")]
        public double FloatValue { get; set; }

        [JsonProperty(PropertyName = "account_info")]
        public EconItemAttributeAccountInfo AccountInfo { get; set; }
    }

    internal class EconItem
    {
        public ulong Id { get; set; }

        [JsonProperty(PropertyName = "original_id")]
        public ulong OriginalId { get; set; }

        public uint DefIndex { get; set; }
        public uint Level { get; set; }
        public uint Quality { get; set; }
        public ulong Inventory { get; set; }
        public uint Quantity { get; set; }
        public uint Origin { get; set; }
        public IList<EconItemEquipped> Equipped { get; set; }
        public uint Style { get; set; }
        public IList<EconItemAttribute> Attributes { get; set; }

        [JsonProperty(PropertyName = "flag_cannot_trade")]
        public bool? FlagCannotTrade { get; set; }

        [JsonProperty(PropertyName = "flag_cannot_craft")]
        public bool? FlagCannotCraft { get; set; }
    }
}