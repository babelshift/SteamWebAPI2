using Steam.Models;
using SteamWebAPI2.Models;
using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public enum GCVersionAppId
    {
        TeamFortress2 = 440,
        Dota2 = 570,
        CounterStrikeGO = 730
    }

    public class GCVersion : IGCVersion
    {
        private uint appId;

        // The API only exposes certain methods for certain App Ids in the EconItems interface
        // I'm hard coding the values for now until I come up with a better, more dynamic solution
        private List<uint> validClientVersionAppIds = new List<uint>();

        private List<uint> validServerVersionAppIds = new List<uint>();

        private ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebApiKey"></param>
        public GCVersion(string steamWebApiKey, GCVersionAppId appId, ISteamWebInterface steamWebInterface = null)
        {
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface(steamWebApiKey, "IGCVersion_" + (uint)appId)
                : steamWebInterface;

            if (appId <= 0)
            {
                throw new ArgumentOutOfRangeException("appId");
            }

            this.appId = (uint)appId;

            validClientVersionAppIds.Add(440);
            validClientVersionAppIds.Add(570);

            validServerVersionAppIds.Add(440);
            validServerVersionAppIds.Add(570);
            validServerVersionAppIds.Add(730);
        }

        /// <summary>
        /// Returns the most recent client version number based on a specific App ID.
        /// </summary>
        /// <returns></returns>
        public async Task<ISteamWebResponse<GameClientResultModel>> GetClientVersionAsync()
        {
            if (!validClientVersionAppIds.Contains(appId))
            {
                throw new InvalidOperationException(String.Format("AppId {0} is not valid for the GetClientVersion method.", appId));
            }

            var steamWebResponse = await steamWebInterface.GetAsync<GameClientResultContainer>("GetClientVersion", 1);

            var steamWebResponseModel = AutoMapperConfiguration.Mapper.Map<ISteamWebResponse<GameClientResultContainer>, ISteamWebResponse<GameClientResultModel>>(steamWebResponse);

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
                throw new InvalidOperationException(String.Format("AppId {0} is not valid for the GetServerVersion method.", appId));
            }

            var steamWebResponse = await steamWebInterface.GetAsync<GameClientResultContainer>("GetServerVersion", 1);

            var steamWebResponseModel = AutoMapperConfiguration.Mapper.Map<ISteamWebResponse<GameClientResultContainer>, ISteamWebResponse<GameClientResultModel>>(steamWebResponse);

            return steamWebResponseModel;
        }
    }
}