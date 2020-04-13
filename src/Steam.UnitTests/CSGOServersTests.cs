using Microsoft.Extensions.Configuration;
using Steam.Models.CSGO;
using SteamWebAPI2.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Steam.UnitTests
{
    public class CSGOServersTests : BaseTest
    {
        [Fact]
        public async Task GetGameMapsPlaytimeAsync_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<CSGOServers>(new HttpClient());
            var response = await steamInterface.GetGameMapsPlaytimeAsync(
                GameMapsPlaytimeInterval.Week, 
                GameMapsPlaytimeGameMode.Competitive, 
                GameMapsPlaytimeMapGroup.Operation
            );
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetGameServerStatusAsync_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<CSGOServers>(new HttpClient());
            var response = await steamInterface.GetGameServerStatusAsync();
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
    }
}
