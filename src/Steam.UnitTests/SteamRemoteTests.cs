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
        public async Task GetPublishedFileDetailsAsync_Should_Succeed()
        {
            var response = await steamInterface.GetPublishedFileDetailsAsync(1673456286);
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
    }
}
