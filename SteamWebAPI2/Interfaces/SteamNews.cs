using SteamWebAPI2.Models;
using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class SteamNews : SteamWebInterface
    {
        public SteamNews(string steamWebApiKey)
            : base(steamWebApiKey, "ISteamNews")
        {
        }

        public async Task<SteamNewsResult> GetNewsForAppAsync(int appId, int? maxLength = null, DateTime? endDate = null, int? count = null)
        {
            long? endDateUnixTimeStamp = null;

            if (endDate.HasValue)
            {
                endDateUnixTimeStamp = endDate.Value.ToUnixTimeStamp();
            }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue("appid", appId, parameters);
            AddToParametersIfHasValue("maxlength", maxLength, parameters);
            AddToParametersIfHasValue("enddate", endDateUnixTimeStamp, parameters);
            AddToParametersIfHasValue("count", count, parameters);

            var appNews = await CallMethodAsync<SteamNewsResultContainer>("GetNewsForApp", 2, parameters);
            return appNews.Result;
        }
    }
}