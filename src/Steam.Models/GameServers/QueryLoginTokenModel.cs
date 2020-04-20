namespace Steam.Models.GameServers
{
    public class QueryLoginTokenModel
    {
        public bool IsBanned { get; set; }

        public uint Expires { get; set; }

        public ulong SteamId { get; set; }
    }
}