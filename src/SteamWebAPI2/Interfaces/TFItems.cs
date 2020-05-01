using AutoMapper;
using Steam.Models.TF2;
using SteamWebAPI2.Models.TF2;
using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class TFItems : ITFItems
    {
        private readonly ISteamWebInterface steamWebInterface;
        private readonly IMapper mapper;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebRequest"></param>
        public TFItems(IMapper mapper, ISteamWebRequest steamWebRequest, ISteamWebInterface steamWebInterface = null)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            
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

            var steamWebResponseModel = mapper.Map<
                ISteamWebResponse<GoldenWrenchResultContainer>,
                ISteamWebResponse<IReadOnlyCollection<GoldenWrenchModel>>>(steamWebResponse);

            return steamWebResponseModel;
        }
    }
}