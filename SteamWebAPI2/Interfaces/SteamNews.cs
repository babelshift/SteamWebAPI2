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

        public async Task<SteamNewsResultModel> GetNewsForAppAsync(int appId, int? maxLength = null, DateTime? endDate = null, int? count = null)
        {
            long? endDateUnixTimeStamp = null;

            if (endDate.HasValue)
            {
                endDateUnixTimeStamp = endDate.Value.ToUnixTimeStamp();
            }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue(appId, "appid", parameters);
            AddToParametersIfHasValue(maxLength, "maxlength", parameters);
            AddToParametersIfHasValue(endDateUnixTimeStamp, "enddate", parameters);
            AddToParametersIfHasValue(count, "count", parameters);

            var appNews = await CallMethodAsync<SteamNewsResultContainer>("GetNewsForApp", 2, parameters);

            var appNewsModel = AutoMapperConfiguration.Mapper.Map<SteamNewsResult, SteamNewsResultModel>(appNews.Result);

            return appNewsModel;
        }
    }
}