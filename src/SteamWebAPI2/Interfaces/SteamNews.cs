using Steam.Models;
using SteamWebAPI2.Models;
using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class SteamNews : ISteamNews
    {
        private ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebApiKey"></param>
        public SteamNews(string steamWebApiKey, ISteamWebInterface steamWebInterface = null)
        {
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface(steamWebApiKey, "ISteamNews")
                : steamWebInterface;
        }

        /// <summary>
        /// Returns the news related to a specific app. This is similar to subscribing to various Valve RSS feeds.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="maxLength"></param>
        /// <param name="endDate"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<SteamNewsResultModel>> GetNewsForAppAsync(uint appId, uint? maxLength = null, DateTime? endDate = null, uint? count = null)
        {
            ulong? endDateUnixTimeStamp = null;

            if (endDate.HasValue)
            {
                endDateUnixTimeStamp = endDate.Value.ToUnixTimeStamp();
            }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(maxLength, "maxlength");
            parameters.AddIfHasValue(endDateUnixTimeStamp, "enddate");
            parameters.AddIfHasValue(count, "count");

            var steamWebResponse = await steamWebInterface.GetAsync<SteamNewsResultContainer>("GetNewsForApp", 2, parameters);

            var steamWebResponseModel = AutoMapperConfiguration.Mapper.Map<
                ISteamWebResponse<SteamNewsResultContainer>, 
                ISteamWebResponse<SteamNewsResultModel>>(steamWebResponse);

            return steamWebResponseModel;
        }
    }
}