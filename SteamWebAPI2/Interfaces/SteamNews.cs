using Steam.Models;
using SteamWebAPI2.Models;
using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class SteamNews : SteamWebInterface, ISteamNews
    {
        public SteamNews(string steamWebApiKey)
            : base(steamWebApiKey, "ISteamNews")
        {
        }

        /// <summary>
        /// Returns the news related to a specific app. This is similar to subscribing to various Valve RSS feeds.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="maxLength"></param>
        /// <param name="endDate"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<SteamNewsResultModel> GetNewsForAppAsync(int appId, int? maxLength = null, DateTime? endDate = null, int? count = null)
        {
            long? endDateUnixTimeStamp = null;

            if (endDate.HasValue)
            {
                endDateUnixTimeStamp = endDate.Value.ToUnixTimeStamp();
            }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(maxLength, "maxlength");
            parameters.AddIfHasValue(endDateUnixTimeStamp, "enddate");
            parameters.AddIfHasValue(count, "count");

            var appNews = await GetAsync<SteamNewsResultContainer>("GetNewsForApp", 2, parameters);

            var appNewsModel = AutoMapperConfiguration.Mapper.Map<SteamNewsResult, SteamNewsResultModel>(appNews.Result);

            return appNewsModel;
        }
    }
}