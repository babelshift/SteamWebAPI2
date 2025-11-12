using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteamWebAPI2.Interfaces;
using System.Threading.Tasks;

namespace Steam.UnitTests
{
    [TestClass]
    public class SteamStoreTests
    {
        private readonly SteamStore steamStore;

        public SteamStoreTests()
        {
            steamStore = new SteamStore(null);
        }

        [TestMethod]
        public async Task GetStoreAppDetailsAsync_Should_Succeed()
        {
            var response = await steamStore.GetStoreAppDetailsAsync(1086940);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Name);
        }

        [TestMethod]
        public async Task GetStoreAppDetailsAsync_WithCurrency_Should_Succeed()
        {
            var response = await steamStore.GetStoreAppDetailsAsync(1086940, "mx");
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.PriceOverview?.Currency);
            Assert.AreEqual("MXN", response.PriceOverview.Currency);
        }

        [TestMethod]
        public async Task GetStoreAppDetailsAsync_WithLanguage_Should_Succeed()
        {
            var response = await steamStore.GetStoreAppDetailsAsync(1086940, "german");
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Name);
        }
    }
}
