using SteamWebAPI2.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Steam.UnitTests
{
    public class SteamNewsTests : BaseTest
    {
        private readonly SteamNews steamInterface;

        public SteamNewsTests()
        {
            steamInterface = factory.CreateSteamWebInterface<SteamNews>(new HttpClient());
        }
        
        [Fact]
        public async Task GetNewsForAppAsync_Should_Succeed()
        {
            var response = await steamInterface.GetNewsForAppAsync(440);
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
    }
}
