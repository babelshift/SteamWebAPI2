using Steam.Models;
using SteamWebAPI2.Models;
using SteamWebAPI2.Utilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class SteamWebAPIUtil : ISteamWebAPIUtil
    {
        private ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebApiKey"></param>
        public SteamWebAPIUtil(string steamWebApiKey, ISteamWebInterface steamWebInterface = null)
        {
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface(steamWebApiKey, "ISteamWebAPIUtil")
                : steamWebInterface;
        }

        /// <summary>
        /// Returns the Steam Servers' known dates and times.
        /// </summary>
        /// <returns></returns>
        public async Task<SteamServerInfoModel> GetServerInfoAsync()
        {
            var steamServerInfo = await steamWebInterface.GetAsync<SteamServerInfo>("GetServerInfo", 1);

            var steamServerInfoModel = AutoMapperConfiguration.Mapper.Map<SteamServerInfo, SteamServerInfoModel>(steamServerInfo);

            return steamServerInfoModel;
        }

        /// <summary>
        /// Returns a collection of data related to all available supported Steam Web API endpoints.
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<SteamInterfaceModel>> GetSupportedAPIListAsync()
        {
            var steamApiListContainer = await steamWebInterface.GetAsync<SteamApiListContainer>("GetSupportedAPIList", 1);

            var steamApiListModel = AutoMapperConfiguration.Mapper.Map<IList<SteamInterface>, IList<SteamInterfaceModel>>(steamApiListContainer.Result.Interfaces);

            return new ReadOnlyCollection<SteamInterfaceModel>(steamApiListModel);
        }
    }
}