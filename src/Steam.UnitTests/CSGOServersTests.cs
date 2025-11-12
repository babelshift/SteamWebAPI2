using Microsoft.VisualStudio.TestTools.UnitTesting;
using Steam.Models.CSGO;
using SteamWebAPI2.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace Steam.UnitTests
{
    [TestClass]
    public class CSGOServersTests : BaseTest
    {
        [TestMethod]
        public async Task GetGameMapsPlaytimeAsync_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<CSGOServers>(new HttpClient());
            var response = await steamInterface.GetGameMapsPlaytimeAsync(
                GameMapsPlaytimeInterval.Week,
                GameMapsPlaytimeGameMode.Competitive,
                GameMapsPlaytimeMapGroup.Operation
            );
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task GetGameServerStatusAsync_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<CSGOServers>(new HttpClient());
            var response = await steamInterface.GetGameServerStatusAsync();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }
    }
}
