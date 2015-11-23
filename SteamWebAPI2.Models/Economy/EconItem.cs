using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models.Economy
{
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
