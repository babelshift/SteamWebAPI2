using System.Collections.Generic;

namespace Steam.Models
{
    public class AvailableGameStatsModel
    {
        public IReadOnlyCollection<SchemaGameStatModel> Stats { get; set; }

        public IReadOnlyCollection<SchemaGameAchievementModel> Achievements { get; set; }
    }
}