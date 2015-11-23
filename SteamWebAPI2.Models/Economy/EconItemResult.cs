using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models.Economy
{
    public class EconItemResult
    {
        public int Status { get; set; }
        [JsonProperty(PropertyName = "num_backpack_slots")]
        public int NumBackpackSlots { get; set; }
        public IList<EconItem> Items { get; set; }
    }
}
