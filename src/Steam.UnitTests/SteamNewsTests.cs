using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteamWebAPI2.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace Steam.UnitTests
{
    [TestClass]
    public class SteamNewsTests : BaseTest
    {
        private readonly SteamNews steamInterface;

        public SteamNewsTests()
        {
            steamInterface = factory.CreateSteamWebInterface<SteamNews>(new HttpClient());
        }

        [TestMethod]
        public async Task GetNewsForAppAsync_Should_Succeed()
        {
            var response = await steamInterface.GetNewsForAppAsync(440);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }
    }
}
