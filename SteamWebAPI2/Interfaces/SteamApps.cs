using Steam.Models;
using SteamWebAPI2.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SteamWebAPI2.Utilities;

namespace SteamWebAPI2.Interfaces
{
    public class SteamApps : ISteamApps
    {
        private ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebApiKey"></param>
        public SteamApps(string steamWebApiKey, ISteamWebInterface steamWebInterface = null)
        {
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface(steamWebApiKey, "ISteamApps")
                : steamWebInterface;
        }

        /// <summary>
        /// Returns a list of all Steam Apps.
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<SteamAppModel>> GetAppListAsync()
        {
            var steamAppList = await steamWebInterface.GetAsync<SteamAppListResultContainer>("GetAppList", 2);
            var steamAppModels = AutoMapperConfiguration.Mapper.Map<IList<SteamApp>, IList<SteamAppModel>>(steamAppList.Result.Apps);
            return new ReadOnlyCollection<SteamAppModel>(steamAppModels);
        }

        /// <summary>
        /// Checks if a specific version of a specific Steam App is up to date with the Steam servers.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public async Task<SteamAppUpToDateCheckModel> UpToDateCheckAsync(int appId, int version)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(version, "version");

            var upToDateCheckResult = await steamWebInterface.GetAsync<SteamAppUpToDateCheckResultContainer>("UpToDateCheck", 1, parameters);
            var upToDateCheckModel = AutoMapperConfiguration.Mapper.Map<SteamAppUpToDateCheckResult, SteamAppUpToDateCheckModel>(upToDateCheckResult.Result);
            return upToDateCheckModel;
        }
    }
}