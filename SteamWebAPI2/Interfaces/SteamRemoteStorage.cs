using Steam.Models;
using SteamWebAPI2.Models;
using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class SteamRemoteStorage : SteamWebInterface, ISteamRemoteStorage
    {
        public SteamRemoteStorage(string steamWebApiKey)
            : base(steamWebApiKey, "ISteamRemoteStorage")
        {
        }

        public async Task<UGCFileDetailsModel> GetUGCFileDetailsAsync(long ugcId, int appId, long? steamId = null)
        {
            Debug.Assert(appId > 0);

            if (ugcId <= 0)
            {
                return null;
            }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue(ugcId, "ugcid", parameters);
            AddToParametersIfHasValue(appId, "appid", parameters);
            AddToParametersIfHasValue(steamId, "steamid", parameters);

            try
            {
                var ugcFileDetails = await CallMethodAsync<UGCFileDetailsResultContainer>("GetUGCFileDetails", 1, parameters);

                var ugcFileDetailsModel = AutoMapperConfiguration.Mapper.Map<UGCFileDetails, UGCFileDetailsModel>(ugcFileDetails.Result);

                return ugcFileDetailsModel;
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
    }
}