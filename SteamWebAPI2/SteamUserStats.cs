using SteamWebAPI2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2
{
    public class SteamUserStats : SteamWebInterface
    {
        public SteamUserStats(string steamWebApiKey)
            : base(steamWebApiKey, "ISteamUserStats")
        { }

        public async Task<IReadOnlyCollection<GlobalAchievementPercentage>> GetGlobalAchievementPercentagesForAppAsync(long appId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            AddToParametersIfHasValue("gameid", appId, parameters);
            var achievementPercentagesResult = await CallMethodAsync<GlobalAchievementPercentagesResultContainer>("GetGlobalAchievementPercentagesForApp", 2, parameters);
            return new ReadOnlyCollection<GlobalAchievementPercentage>(achievementPercentagesResult.Result.AchievementPercentages);
        }

        public async Task<GlobalStatsForGameResult> GetGlobalStatsForGameAsync(long appId, IReadOnlyList<string> statNames)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            AddToParametersIfHasValue("appid", appId, parameters);
            AddToParametersIfHasValue("count", statNames.Count, parameters);

            for (int i = 0; i < statNames.Count; i++)
            {
                AddToParametersIfHasValue(String.Format("name[{0}]", i), statNames[i], parameters);
            }

            var globalStatsResult = await CallMethodAsync<GlobalStatsForGameResultContainer>("GetGlobalStatsForGame", 1, parameters);
            return globalStatsResult.Result;
        }
    }
}
