using AutoMapper;
using Steam.Models;
using SteamWebAPI2.Models;
using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class SteamApps : ISteamApps
    {
        private readonly IMapper mapper;
        private readonly ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebRequest"></param>
        public SteamApps(IMapper mapper, ISteamWebRequest steamWebRequest, ISteamWebInterface steamWebInterface = null)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface("ISteamApps", steamWebRequest)
                : steamWebInterface;
        }

        /// <summary>
        /// Returns a list of all Steam Apps.
        /// </summary>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<SteamAppModel>>> GetAppListAsync()
        {
            var steamWebResponse = await steamWebInterface.GetAsync<SteamAppListResultContainer>("GetAppList", 2);

            var steamWebResponseModel = mapper.Map<
                ISteamWebResponse<SteamAppListResultContainer>,
                ISteamWebResponse<IReadOnlyCollection<SteamAppModel>>>(steamWebResponse);

            return steamWebResponseModel;
        }

        /// <summary>
        /// Checks if a specific version of a specific Steam App is up to date with the Steam servers.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<SteamAppUpToDateCheckModel>> UpToDateCheckAsync(uint appId, uint version)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(version, "version");

            var steamWebResponse = await steamWebInterface.GetAsync<SteamAppUpToDateCheckResultContainer>("UpToDateCheck", 1, parameters);

            var steamWebResponseModel = mapper.Map<
                ISteamWebResponse<SteamAppUpToDateCheckResultContainer>,
                ISteamWebResponse<SteamAppUpToDateCheckModel>>(steamWebResponse);

            return steamWebResponseModel;
        }
    }
}