
using Steam.Models;
using SteamWebAPI2.Models;
using SteamWebAPI2.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SteamWebAPI2.Interfaces
{
    public class SteamApps : ISteamApps
    {
        private readonly ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebRequest"></param>
        public SteamApps(ISteamWebRequest steamWebRequest, ISteamWebInterface steamWebInterface = null)
        {
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

            return steamWebResponse.MapTo<IReadOnlyCollection<SteamAppModel>>((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return result.Apps?.Select(a => new SteamAppModel
                {
                    AppId = a.AppId,
                    Name = a.Name
                }).ToList().AsReadOnly();
            });
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

            return steamWebResponse.MapTo((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return new SteamAppUpToDateCheckModel
                {
                    Success = result.Success,
                    UpToDate = result.UpToDate,
                    VersionIsListable = result.VersionIsListable,
                    RequiredVersion = result.RequiredVersion,
                    Message = result.Message
                };
            });
        }
    }
}