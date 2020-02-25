using System.Collections.Generic;

namespace Steam.Models.SteamCommunity
{
    public class OwnedGamesResultModel
    {
        public uint GameCount { get; set; }

        public IReadOnlyCollection<OwnedGameModel> OwnedGames { get; set; }
    }
}