using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteamWebAPI2.Interfaces;
using System.Threading.Tasks;
using System.Configuration;

namespace SteamWebAPI2.Tests
{
    [TestClass]
    public class PlayerServiceTests
    {
        private string steamWebApiKey = String.Empty;

        [TestInitialize]
        public void Initialize()
        {
            steamWebApiKey = ConfigurationManager.AppSettings["steamWebApiKey"].ToString();
        }

        [TestMethod]
        public async Task PlayerService_GetPlayerSummaryAsync()
        {
            var playerService = new PlayerService(steamWebApiKey);
            var response = await playerService.GetOwnedGamesAsync(76561197960361544);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.OwnedGames);
            Assert.IsTrue(response.GameCount > 0);
            Assert.IsTrue(response.OwnedGames.Count > 0);
        }
    }
}
