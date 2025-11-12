using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteamWebAPI2.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace Steam.UnitTests
{
    [TestClass]
    public class PlayerServiceTests : BaseTest
    {
        private readonly PlayerService steamInterface;

        public PlayerServiceTests()
        {
            steamInterface = factory.CreateSteamWebInterface<PlayerService>(new HttpClient());
        }

        // Commented out until I can figure out how to get a valid response from this endpoint.
        // [TestMethod]
        // public async Task GetCommunityBadgeProgressAsync_Should_Succeed()
        // {
        //     var response = await steamInterface.GetCommunityBadgeProgressAsync(76561198050013009);
        //     Assert.IsNotNull(response);
        //     Assert.IsNotNull(response.Data);
        // }

        [TestMethod]
        public async Task GetBadgesAsync_Should_Succeed()
        {
            var response = await steamInterface.GetBadgesAsync(76561198050013009);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task GetSteamLevelAsync_Should_Succeed()
        {
            var response = await steamInterface.GetSteamLevelAsync(76561198050013009);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task GetOwnedGamesAsync_Should_Succeed()
        {
            var response = await steamInterface.GetOwnedGamesAsync(76561198050013009);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task GetRecentlyPlayedGames_Should_Succeed()
        {
            var response = await steamInterface.GetRecentlyPlayedGamesAsync(76561198050013009);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }
    }
}
