using System.Collections.Generic;

namespace Steam.Models.DOTA2
{
    public class ProPlayerDetailModel
    {
        public IReadOnlyCollection<ProPlayerInfoModel> ProPlayers { get; set; }

        public IReadOnlyCollection<ProPlayerLeaderboardModel> Leaderboards { get; set; }
    }
}