using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.DOTA2
{
    internal class GameItem
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public uint Cost { get; set; }

        [JsonProperty(PropertyName = "secret_shop")]
        public ushort SecretShop { get; set; }

        [JsonProperty(PropertyName = "side_shop")]
        public ushort SideShop { get; set; }

        public ushort Recipe { get; set; }

        [JsonProperty(PropertyName = "localized_name")]
        public string LocalizedName { get; set; }

        public bool IsAvailableAtSecretShop {  get { return SecretShop == 1 ? true : false; } }
        public bool IsAvailableAtSideShop { get { return SideShop == 1 ? true : false; } }
        public bool IsRecipe { get { return Recipe == 1 ? true : false; } }
    }

    internal class GameItemResult
    {
        public IList<GameItem> Items { get; set; }
    }

    internal class GameItemResultContainer
    {
        public GameItemResult Result { get; set; }
    }
}