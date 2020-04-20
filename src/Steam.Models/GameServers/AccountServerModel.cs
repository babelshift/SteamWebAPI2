using System;

namespace Steam.Models.GameServers
{
    public class AccountServerModel
    {
        /// <summary>Steam ID of the game server.
        /// </summary>
        public ulong SteamId { get; set; }

        /// <summary>AppId that the game server is associated with such as TF2 or CS:GO
        /// </summary>
        public uint AppId { get; set; }

        public string LoginToken { get; set; }

        public string Memo { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsExpired { get; set; }

        public DateTime? RtLastLogon { get; set; }
    }
}