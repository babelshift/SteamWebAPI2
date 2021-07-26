using System;

namespace Steam.Models.SteamPlayer
{
    public class PlayerAchievementModel
    {
        public string APIName { get; set; }

        public uint Achieved { get; set; }

        public DateTime UnlockTime { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}