using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteamWebAPI2.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace Steam.UnitTests
{
    [TestClass]
    public class SteamAppsTests : BaseTest
    {
        private readonly SteamApps steamInterface;

        public SteamAppsTests()
        {
            steamInterface = factory.CreateSteamWebInterface<SteamApps>(new HttpClient());
        }

        // Always returning 503 on Valve's end. Commenting for now.
        // [TestMethod]
        // public async Task GetAppListAsync_Should_Succeed()
        // {
        //     var response = await steamInterface.GetAppListAsync();
        //     Assert.IsNotNull(response);
        //     Assert.IsNotNull(response.Data);
        // }

        [TestMethod]
        public async Task UpToDateCheckAsync_Should_Succeed()
        {
            var response = await steamInterface.UpToDateCheckAsync(440, 1);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }
    }
}
