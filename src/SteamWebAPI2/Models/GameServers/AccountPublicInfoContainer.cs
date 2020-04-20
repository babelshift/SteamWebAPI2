using Newtonsoft.Json;

namespace SteamWebAPI2.Models.GameServers
{
    public class AccountPublicInfoContainer
    {
        [JsonProperty("response")]
        public AccountPublicInfo Response { get; set; }
    }

    public class AccountPublicInfo
    {
        [JsonProperty("steamid")]
        public ulong SteamId { get; set; }
        
        [JsonProperty("appid")]
        public uint AppId { get; set; }
    }
}