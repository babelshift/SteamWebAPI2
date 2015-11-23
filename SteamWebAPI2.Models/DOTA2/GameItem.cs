using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models.DOTA2
{
    public class GameItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        [JsonProperty(PropertyName ="secret_shop")]
        public int SecretShop { get; set; }
        [JsonProperty(PropertyName = "side_shop")]
        public int SideShop { get; set; }
        public int Recipe { get; set; }
    }
}
