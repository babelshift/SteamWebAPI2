using SteamWebAPI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamWebAPI2.Models.Utilities;

namespace SteamWebAPI2
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

            if(endDate.HasValue)
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
