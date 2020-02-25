using System;

namespace Steam.Models.SteamCommunity
{
    public class FriendModel
    {
        public ulong SteamId { get; set; }

        public string Relationship { get; set; }

        public DateTime FriendSince { get; set; }
    }
}