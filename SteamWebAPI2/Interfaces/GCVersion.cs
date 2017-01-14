using Steam.Models;
using SteamWebAPI2.Models;
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

    public class GCVersion : SteamWebInterface, IGCVersion
    {
        private int appId;

        // The API only exposes certain methods for certain App Ids in the EconItems interface
        // I'm hard coding the values for now until I come up with a better, more dynamic solution
        private List<int> validClientVersionAppIds = new List<int>();

        private List<int> validServerVersionAppIds = new List<int>();

        public GCVersion(string steamWebApiKey, GCVersionAppId appId)
            : base(steamWebApiKey, "IGCVersion_" + (int)appId)
        {
            if (appId <= 0)
            {
                throw new ArgumentOutOfRangeException("appId");
            }

            this.appId = (int)appId;

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
        public async Task<GameClientResultModel> GetClientVersionAsync()
        {
            if (!validClientVersionAppIds.Contains(appId))
            {
                throw new InvalidOperationException(String.Format("AppId {0} is not valid for the GetClientVersion method.", appId));
            }

            var clientVersion = await GetAsync<GameClientResultContainer>("GetClientVersion", 1);

            var clientVersionModel = AutoMapperConfiguration.Mapper.Map<GameClientResult, GameClientResultModel>(clientVersion.Result);

            return clientVersionModel;
        }

        /// <summary>
        /// Returns the most recent server version number based on a specific App ID.
        /// </summary>
        /// <returns></returns>
        public async Task<GameClientResultModel> GetServerVersionAsync()
        {
            if (!validServerVersionAppIds.Contains(appId))
            {
                throw new InvalidOperationException(String.Format("AppId {0} is not valid for the GetServerVersion method.", appId));
            }

            var serverVersion = await GetAsync<GameClientResultContainer>("GetServerVersion", 1);

            var serverVersionModel = AutoMapperConfiguration.Mapper.Map<GameClientResult, GameClientResultModel>(serverVersion.Result);

            return serverVersionModel;
        }
    }
}