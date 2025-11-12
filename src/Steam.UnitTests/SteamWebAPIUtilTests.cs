using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteamWebAPI2.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace Steam.UnitTests
{
    [TestClass]
    public class SteamWebAPIUtilTests : BaseTest
    {
        private readonly SteamWebAPIUtil steamInterface;

        public SteamWebAPIUtilTests()
        {
            steamInterface = factory.CreateSteamWebInterface<SteamWebAPIUtil>(new HttpClient());
        }

        [TestMethod]
        public async Task GetServerInfoAsync_Should_Succeed()
        {
            var response = await steamInterface.GetServerInfoAsync();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task GetSupportedAPIListAsync_Should_Succeed()
        {
            var response = await steamInterface.GetSupportedAPIListAsync();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }
    }
}
