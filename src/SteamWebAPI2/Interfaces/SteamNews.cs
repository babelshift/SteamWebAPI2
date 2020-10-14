using AutoMapper;
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
        private readonly ISteamWebInterface steamWebInterface;
        private readonly IMapper mapper;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebRequest"></param>
        public SteamNews(IMapper mapper, ISteamWebRequest steamWebRequest, ISteamWebInterface steamWebInterface = null)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface("ISteamNews", steamWebRequest)
                : steamWebInterface;
        }

        /// <summary>
        /// Returns the news related to a specific app. This is similar to subscribing to various Valve RSS feeds.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="maxLength"></param>
        /// <param name="endDate"></param>
        /// <param name="count"></param>
        /// <param name="feeds"></param>
        /// <param name="tags"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<SteamNewsResultModel>> GetNewsForAppAsync(uint appId, uint? maxLength = null, DateTime? endDate = null, uint? count = null, string feeds = null, string[] tags = null)
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
            parameters.AddIfHasValue(feeds, "feeds");
            parameters.AddIfHasValue(tags, "tags"); 

            var steamWebResponse = await steamWebInterface.GetAsync<SteamNewsResultContainer>("GetNewsForApp", 2, parameters);

            var steamWebResponseModel = mapper.Map<
                ISteamWebResponse<SteamNewsResultContainer>,
                ISteamWebResponse<SteamNewsResultModel>>(steamWebResponse);

            return steamWebResponseModel;
        }
    }
}