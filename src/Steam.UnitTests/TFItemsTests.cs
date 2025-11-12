using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteamWebAPI2.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace Steam.UnitTests
{
    [TestClass]
    public class TFItemsTests : BaseTest
    {
        private readonly TFItems steamInterface;

        public TFItemsTests()
        {
            steamInterface = factory.CreateSteamWebInterface<TFItems>(new HttpClient());
        }

        [TestMethod]
        public async Task GetServerInfoAsync_Should_Succeed()
        {
            var response = await steamInterface.GetGoldenWrenchesAsync();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }
    }
}
