using System.Collections.Generic;

namespace Steam.Models.SteamCommunity
{
    public class RecentlyPlayedGamesResultModel
    {
        public uint TotalCount { get; set; }

        public IReadOnlyCollection<RecentlyPlayedGameModel> RecentlyPlayedGames { get; set; }
    }
}