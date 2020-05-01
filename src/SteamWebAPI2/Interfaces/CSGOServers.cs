using AutoMapper;
using Steam.Models.CSGO;
using SteamWebAPI2.Models.CSGO;
using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    /// <summary>
    /// Represents a Steam Web API interface endpoint located at ICSGOServers_730
    /// </summary>
    public class CSGOServers : ICSGOServers
    {
        private readonly IMapper mapper;
        private readonly ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebApiKey"></param>
        public CSGOServers(IMapper mapper, ISteamWebRequest steamWebRequest, ISteamWebInterface steamWebInterface = null)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface("ICSGOServers_730", steamWebRequest)
                : steamWebInterface;
        }

        /// <summary>
        /// Maps to the Steam Web API interface/method of ICSGOServers_730/GetGameMapsPlaytime/v1
        /// </summary>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IEnumerable<GameMapsPlaytimeModel>>> GetGameMapsPlaytimeAsync(
            GameMapsPlaytimeInterval interval, 
            GameMapsPlaytimeGameMode gameMode, 
            GameMapsPlaytimeMapGroup mapGroup
        )
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            
            parameters.AddIfHasValue(interval.ToString().ToLower(), "interval");
            parameters.AddIfHasValue(gameMode.ToString().ToLower(), "gamemode");
            parameters.AddIfHasValue(mapGroup.ToString().ToLower(), "mapgroup");

            var steamWebResponse = await steamWebInterface.GetAsync<GameMapsPlaytimeContainer>("GetGameMapsPlaytime", 1, parameters);

            var steamWebResponseModel = mapper.Map<
                ISteamWebResponse<GameMapsPlaytimeContainer>, 
                ISteamWebResponse<IEnumerable<GameMapsPlaytimeModel>>>(steamWebResponse);

            return steamWebResponseModel;
        }

        /// <summary>
        /// Maps to the Steam Web API interface/method of ICSGOServers_730/GetGameServersStatus/v1
        /// </summary>
        /// <returns></returns>
        public async Task<ISteamWebResponse<ServerStatusModel>> GetGameServerStatusAsync()
        {
            var steamWebResponse = await steamWebInterface.GetAsync<ServerStatusResultContainer>("GetGameServersStatus", 1);

            var steamWebResponseModel = mapper.Map<ISteamWebResponse<ServerStatusResultContainer>, ISteamWebResponse<ServerStatusModel>>(steamWebResponse);

            return steamWebResponseModel;
        }
    }
}