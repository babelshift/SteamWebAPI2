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

        public async Task<SteamServerInfoModel> GetServerInfoAsync()
        {
            var steamServerInfo = await CallMethodAsync<SteamServerInfo>("GetServerInfo", 1);

            var steamServerInfoModel = AutoMapperConfiguration.Mapper.Map<SteamServerInfo, SteamServerInfoModel>(steamServerInfo);

            return steamServerInfoModel;
        }

        public async Task<IReadOnlyCollection<SteamInterfaceModel>> GetSupportedAPIListAsync()
        {
            var steamApiListContainer = await CallMethodAsync<SteamApiListContainer>("GetSupportedAPIList", 1);

            var steamApiListModel = AutoMapperConfiguration.Mapper.Map<IList<SteamInterface>, IList<SteamInterfaceModel>>(steamApiListContainer.Result.Interfaces);

            return new ReadOnlyCollection<SteamInterfaceModel>(steamApiListModel);
        }
    }
}