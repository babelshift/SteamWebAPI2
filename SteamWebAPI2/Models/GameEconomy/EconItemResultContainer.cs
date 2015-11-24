/*
*
*   These are models related to the JSON response of the GetPlayerItems method from various IEconItems_<AppId> interfaces.
*
*/

using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.GameEconomy
{
    internal class EconItemResultContainer
    {
        public EconItemResult Result { get; set; }
    }

    public class EconItemResult
    {
        public int Status { get; set; }

        [JsonProperty(PropertyName = "num_backpack_slots")]
        public int NumBackpackSlots { get; set; }

        public IList<EconItem> Items { get; set; }
    }

    public class EconItemEquipped
    {
        [JsonProperty(PropertyName = "class")]
        public int ClassId { get; set; }

        public int Slot { get; set; }
    }

    public class EconItemAttributeAccountInfo
    {
        public long SteamId { get; set; }
        public string PersonaName { get; set; }
    }

    public class EconItemAttribute
    {
        public int DefIndex { get; set; }
        public long Value { get; set; }

        [JsonProperty(PropertyName = "float_value")]
        public double FloatValue { get; set; }

        [JsonProperty(PropertyName = "account_info")]
        public EconItemAttributeAccountInfo AccountInfo { get; set; }
    }

    public class EconItem
    {
        public long Id { get; set; }

        [JsonProperty(PropertyName = "original_id")]
        public long OriginalId { get; set; }

        public int DefIndex { get; set; }
        public int Level { get; set; }
        public int Quality { get; set; }
        public long Inventory { get; set; }
        public int Quantity { get; set; }
        public int Origin { get; set; }
        public IList<EconItemEquipped> Equipped { get; set; }
        public int Style { get; set; }
        public IList<EconItemAttribute> Attributes { get; set; }

        [JsonProperty(PropertyName = "flag_cannot_trade")]
        public bool? FlagCannotTrade { get; set; }

        [JsonProperty(PropertyName = "flag_cannot_craft")]
        public bool? FlagCannotCraft { get; set; }
    }
}