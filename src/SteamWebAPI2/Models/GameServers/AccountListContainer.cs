using System.Collections.Generic;
using Newtonsoft.Json;

namespace SteamWebAPI2.Models.GameServers
{
    public class AccountListContainer
    {
        [JsonProperty("response")]
        public AccountList Response { get; set; }
    }

    public class AccountList
    {
        [JsonProperty("servers")]
        public IEnumerable<AccountServer> Servers { get; set; }

        [JsonProperty("is_banned")]
        public bool IsBanned { get; set; }

        [JsonProperty("expires")]
        public uint Expires { get; set; }

        [JsonProperty("actor")]
        public ulong Actor { get; set; }

        [JsonProperty("last_action_time")]
        public ulong LastActionTime { get; set; }
    }

    public class AccountServer
    {
        
        [JsonProperty("steamid")]
        public ulong SteamId { get; set; }
        
        [JsonProperty("appid")]
        public uint AppId { get; set; }
        
        [JsonProperty("login_token")]
        public string LoginToken { get; set; }
        
        [JsonProperty("memo")]
        public string Memo { get; set; }

        [JsonProperty("is_deleted")]
        public bool IsDeleted { get; set; }
        
        [JsonProperty("is_expired")]
        public bool IsExpired { get; set; }
        
        [JsonProperty("rt_last_logon")]
        public ulong RtLastLogon { get; set; }
    }
}