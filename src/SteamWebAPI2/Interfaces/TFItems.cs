using Steam.Models.TF2;
using SteamWebAPI2.Models.TF2;
using SteamWebAPI2.Utilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class TFItems : ITFItems
    {
        private ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebApiKey"></param>
        public TFItems(string steamWebApiKey, ISteamWebInterface steamWebInterface = null)
        {
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface(steamWebApiKey, "ITFItems_440")
                : steamWebInterface;
        }

        /// <summary>
        /// Returns a collection of golden wrench and their collection details.
        /// </summary>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<GoldenWrenchModel>>> GetGoldenWrenchesAsync()
        {
            var steamWebResponse = await steamWebInterface.GetAsync<GoldenWrenchResultContainer>("GetGoldenWrenches", 2);

            var steamWebResponseModel = AutoMapperConfiguration.Mapper.Map<
                ISteamWebResponse<GoldenWrenchResultContainer>, 
                ISteamWebResponse<IReadOnlyCollection<GoldenWrenchModel>>>(steamWebResponse);

            return steamWebResponseModel;
        }
    }
}