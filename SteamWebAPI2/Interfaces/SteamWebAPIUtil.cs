using Steam.Models;
using SteamWebAPI2.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class SteamWebAPIUtil : SteamWebInterface, ISteamWebAPIUtil
    {
        public SteamWebAPIUtil(string steamWebApiKey)
            : base(steamWebApiKey, "ISteamWebAPIUtil")
        { }

        /// <summary>
        /// Returns the Steam Servers' known dates and times.
        /// </summary>
        /// <returns></returns>
        public async Task<SteamServerInfoModel> GetServerInfoAsync()
        {
            var steamServerInfo = await GetAsync<SteamServerInfo>("GetServerInfo", 1);

            var steamServerInfoModel = AutoMapperConfiguration.Mapper.Map<SteamServerInfo, SteamServerInfoModel>(steamServerInfo);

            return steamServerInfoModel;
        }

        /// <summary>
        /// Returns a collection of data related to all available supported Steam Web API endpoints.
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<SteamInterfaceModel>> GetSupportedAPIListAsync()
        {
            var steamApiListContainer = await GetAsync<SteamApiListContainer>("GetSupportedAPIList", 1);

            var steamApiListModel = AutoMapperConfiguration.Mapper.Map<IList<SteamInterface>, IList<SteamInterfaceModel>>(steamApiListContainer.Result.Interfaces);

            return new ReadOnlyCollection<SteamInterfaceModel>(steamApiListModel);
        }
    }
}