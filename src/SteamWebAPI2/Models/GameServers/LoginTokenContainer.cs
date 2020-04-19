using Newtonsoft.Json;

namespace SteamWebAPI2.Models.GameServers
{
    public class LoginTokenContainer
    {
        [JsonProperty("response")]
        public LoginTokenResponse Response { get; set; }
    }

    public class LoginTokenResponse
    {
        [JsonProperty("login_token")]
        public string LoginToken { get; set; }
    }
}