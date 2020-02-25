using System.Collections.Generic;

namespace Steam.Models.SteamPlayer
{
    public class PlayerAchievementResultModel
    {
        public ulong SteamId { get; set; }

        public string GameName { get; set; }

        public IReadOnlyCollection<PlayerAchievementModel> Achievements { get; set; }

        public bool Success { get; set; }
    }
}