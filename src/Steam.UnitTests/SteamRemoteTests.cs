using Steam.Models;
using SteamWebAPI2.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Steam.UnitTests
{
    public class SteamRemoteTests : BaseTest
    {
        private readonly SteamRemoteStorage steamInterface;

        public SteamRemoteTests()
        {
            steamInterface = factory.CreateSteamWebInterface<SteamRemoteStorage>(new HttpClient());
        }
        
        [Fact]
        public async Task GetPublishedFileDetailsAsync_Public_Visibility_Should_Succeed()
        {
            var response = await steamInterface.GetPublishedFileDetailsAsync(1673456286);
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
            Assert.Equal(PublishedFileVisibility.Public, response.Data.Visibility);
        }

        [Fact]
        public async Task GetPublishedFileDetailsAsync_Unknown_Visibility_Should_Succeed()
        {
            var response = await steamInterface.GetPublishedFileDetailsAsync(2097579725);
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
            Assert.Equal(PublishedFileVisibility.Unknown, response.Data.Visibility);
        }
    }
}
