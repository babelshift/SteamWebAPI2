using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models.Economy
{
    public class EconItemAttribute
    {
        public int DefIndex { get; set; }
        public long Value { get; set; }
        [JsonProperty(PropertyName = "float_value")]
        public double FloatValue { get; set; }
        [JsonProperty(PropertyName = "account_info")]
        public EconItemAttributeAccountInfo AccountInfo { get; set; }
    }
}
