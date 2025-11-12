using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteamWebAPI2.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Steam.UnitTests
{
    [TestClass]
    public class SteamEconomyTests : BaseTest
    {
        private readonly SteamEconomy steamInterface;

        public SteamEconomyTests()
        {
            steamInterface = factory.CreateSteamWebInterface<SteamEconomy>(new HttpClient());
        }

        [TestMethod]
        public async Task GetAssetClassInfoAsync_Should_Succeed()
        {
            List<ulong> classes = new List<ulong>() { 211447708 };
            var response = await steamInterface.GetAssetClassInfoAsync(440, classes);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task GetAssetPricesAsync_Should_Succeed()
        {
            var response = await steamInterface.GetAssetPricesAsync(440);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }
    }
}
