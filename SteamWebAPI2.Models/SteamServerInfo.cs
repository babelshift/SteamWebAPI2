using SteamWebAPI2.Models.Utilities;
using System;

namespace SteamWebAPI2.Models
{
    public class SteamServerInfo
    {
        public long ServerTime { get; set; }
        public string ServerTimeString { get; set; }
        public DateTime ServerTimeDateTime { get { return ServerTime.ToDateTime(); } }
    }
}