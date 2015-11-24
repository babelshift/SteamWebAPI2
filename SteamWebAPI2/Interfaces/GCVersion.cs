using SteamWebAPI2.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class GCVersion : SteamWebInterface
    {
        private int appId;

        // The API only exposes certain methods for certain App Ids in the EconItems interface
        // I'm hard coding the values for now until I come up with a better, more dynamic solution
        private List<int> validClientVersionAppIds = new List<int>();

        private List<int> validServerVersionAppIds = new List<int>();

        public GCVersion(string steamWebApiKey, int appId)
            : base(steamWebApiKey, "IGCVersion_" + appId)
        {
            if (appId <= 0)
            {
                throw new ArgumentOutOfRangeException("appId");
            }

            this.appId = appId;

            validClientVersionAppIds.Add(440);
            validClientVersionAppIds.Add(570);

            validServerVersionAppIds.Add(440);
            validServerVersionAppIds.Add(570);
            validServerVersionAppIds.Add(730);
        }

        public async Task<GameClientResult> GetClientVersionAsync()
        {
            if (!validClientVersionAppIds.Contains(appId))
            {
                throw new InvalidOperationException(String.Format("AppId {0} is not valid for the GetClientVersion method.", appId));
            }

            var clientVersion = await CallMethodAsync<GameClientResultContainer>("GetClientVersion", 1);
            return clientVersion.Result;
        }

        public async Task<GameClientResult> GetServerVersionAsync()
        {
            if (!validServerVersionAppIds.Contains(appId))
            {
                throw new InvalidOperationException(String.Format("AppId {0} is not valid for the GetServerVersion method.", appId));
            }

            var serverVersion = await CallMethodAsync<GameClientResultContainer>("GetServerVersion", 1);
            return serverVersion.Result;
        }
    }
}