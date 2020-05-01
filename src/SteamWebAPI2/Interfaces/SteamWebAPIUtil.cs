using AutoMapper;
using Steam.Models;
using SteamWebAPI2.Models;
using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class SteamWebAPIUtil : ISteamWebAPIUtil
    {
        private readonly ISteamWebInterface steamWebInterface;
        private readonly IMapper mapper;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebRequest"></param>
        public SteamWebAPIUtil(IMapper mapper, ISteamWebRequest steamWebRequest, ISteamWebInterface steamWebInterface = null)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface("ISteamWebAPIUtil", steamWebRequest)
                : steamWebInterface;
        }

        /// <summary>
        /// Returns the Steam Servers' known dates and times.
        /// </summary>
        /// <returns></returns>
        public async Task<ISteamWebResponse<SteamServerInfoModel>> GetServerInfoAsync()
        {
            var steamServerInfo = await steamWebInterface.GetAsync<SteamServerInfo>("GetServerInfo", 1);

            var steamServerInfoModel = mapper.Map<
                ISteamWebResponse<SteamServerInfo>,
                ISteamWebResponse<SteamServerInfoModel>>(steamServerInfo);

            return steamServerInfoModel;
        }

        /// <summary>
        /// Returns a collection of data related to all available supported Steam Web API endpoints.
        /// </summary>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<SteamInterfaceModel>>> GetSupportedAPIListAsync()
        {
            var steamWebResponse = await steamWebInterface.GetAsync<SteamApiListContainer>("GetSupportedAPIList", 1);

            var steamWebResponseModel = mapper.Map<
                ISteamWebResponse<SteamApiListContainer>,
                ISteamWebResponse<IReadOnlyCollection<SteamInterfaceModel>>>(steamWebResponse);

            return steamWebResponseModel;
        }
    }
}