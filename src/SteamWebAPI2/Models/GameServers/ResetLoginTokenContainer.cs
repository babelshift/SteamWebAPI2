using Newtonsoft.Json;

namespace SteamWebAPI2.Models.GameServers
{
    public class ResetLoginTokenContainer
    {
        [JsonProperty("response")]
        public ResetLoginTokenResponse Response { get; set; }
    }

    public class ResetLoginTokenResponse
    {
        [JsonProperty("login_token")]
        public string LoginToken { get; set; }
    }
}