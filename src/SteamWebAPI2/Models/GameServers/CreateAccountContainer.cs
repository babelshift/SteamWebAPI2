using Newtonsoft.Json;

namespace SteamWebAPI2.Models.GameServers
{
    public class CreateAccountContainer
    {
        [JsonProperty("response")]
        public CreateAccount Response { get; set; }
    }

    public class CreateAccount
    {
        [JsonProperty("steamid")]
        public ulong SteamId { get; set; }
        
        [JsonProperty("login_token")]
        public string LoginToken { get; set; }
    }
}