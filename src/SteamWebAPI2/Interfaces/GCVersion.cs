using AutoMapper;
using Steam.Models;
using SteamWebAPI2.Models;
using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class GCVersion : IGCVersion
    {
        private readonly ISteamWebInterface steamWebInterface;
        private readonly IMapper mapper;

        private uint appId;

        // The API only exposes certain methods for certain App Ids in the EconItems interface
        // I'm hard coding the values for now until I come up with a better, more dynamic solution
        private List<uint> validClientVersionAppIds = new List<uint>();
        private List<uint> validServerVersionAppIds = new List<uint>();

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebRequest"></param>
        public GCVersion(IMapper mapper, ISteamWebRequest steamWebRequest, AppId appId, ISteamWebInterface steamWebInterface = null)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface("IGCVersion_" + (uint)appId, steamWebRequest)
                : steamWebInterface;

            if (appId <= 0)
            {
                throw new ArgumentOutOfRangeException("appId");
            }

            this.appId = (uint)appId;

            validClientVersionAppIds.Add((int)AppId.TeamFortress2);
            validClientVersionAppIds.Add((int)AppId.Dota2);
            validClientVersionAppIds.Add((int)AppId.Artifact);
            validClientVersionAppIds.Add((int)AppId.DotaUnderlords);

            validServerVersionAppIds.Add((int)AppId.TeamFortress2);
            validServerVersionAppIds.Add((int)AppId.Dota2);
            validServerVersionAppIds.Add((int)AppId.CounterStrikeGO);
            validServerVersionAppIds.Add((int)AppId.Artifact);
            validServerVersionAppIds.Add((int)AppId.DotaUnderlords);
        }

        /// <summary>
        /// Returns the most recent client version number based on a specific App ID.
        /// </summary>
        /// <returns></returns>
        public async Task<ISteamWebResponse<GameClientResultModel>> GetClientVersionAsync()
        {
            if (!validClientVersionAppIds.Contains(appId))
            {
                throw new InvalidOperationException(string.Format("AppId {0} is not valid for the GetClientVersion method.", appId));
            }

            var steamWebResponse = await steamWebInterface.GetAsync<GameClientResultContainer>("GetClientVersion", 1);

            var steamWebResponseModel = mapper.Map<ISteamWebResponse<GameClientResultContainer>, ISteamWebResponse<GameClientResultModel>>(steamWebResponse);

            return steamWebResponseModel;
        }

        /// <summary>
        /// Returns the most recent server version number based on a specific App ID.
        /// </summary>
        /// <returns></returns>
        public async Task<ISteamWebResponse<GameClientResultModel>> GetServerVersionAsync()
        {
            if (!validServerVersionAppIds.Contains(appId))
            {
                throw new InvalidOperationException(string.Format("AppId {0} is not valid for the GetServerVersion method.", appId));
            }

            var steamWebResponse = await steamWebInterface.GetAsync<GameClientResultContainer>("GetServerVersion", 1);

            var steamWebResponseModel = mapper.Map<ISteamWebResponse<GameClientResultContainer>, ISteamWebResponse<GameClientResultModel>>(steamWebResponse);

            return steamWebResponseModel;
        }
    }
}