using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Steam.Models.TF2;
using SteamWebAPI2.Models.TF2;
using SteamWebAPI2.Utilities;

namespace SteamWebAPI2.Interfaces
{
    public class TFItems : ITFItems
    {
        private readonly ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebRequest"></param>
        public TFItems(ISteamWebRequest steamWebRequest, ISteamWebInterface steamWebInterface = null)
        {
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface("ITFItems_440", steamWebRequest)
                : steamWebInterface;
        }

        /// <summary>
        /// Returns a collection of golden wrench and their collection details.
        /// </summary>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<GoldenWrenchModel>>> GetGoldenWrenchesAsync()
        {
            var steamWebResponse = await steamWebInterface.GetAsync<GoldenWrenchResultContainer>("GetGoldenWrenches", 2);

            return steamWebResponse.MapTo<IReadOnlyCollection<GoldenWrenchModel>>((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return result.GoldenWrenches?.Select(i => new GoldenWrenchModel
                {
                    ItemId = i.ItemId,
                    SteamId = i.SteamId,
                    WrenchNumber = i.WrenchNumber,
                    Timestamp = i.Timestamp
                }).ToList().AsReadOnly();
            });
        }
    }
}