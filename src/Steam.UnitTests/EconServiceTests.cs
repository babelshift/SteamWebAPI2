using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteamWebAPI2.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace Steam.UnitTests
{
    [TestClass]
    public class EconServiceTests : BaseTest
    {
        private readonly EconService steamInterface;

        public EconServiceTests()
        {
            steamInterface = factory.CreateSteamWebInterface<EconService>(new HttpClient());
        }

        [TestMethod]
        public async Task GetPlayerItemsAsync_Should_Succeed()
        {
            var response = await steamInterface.GetTradeHistoryAsync(10);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task GetTradeOffersAsync_Should_Succeed()
        {
            var response = await steamInterface.GetTradeOffersAsync(true, true);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        // TODO: Figure out how to get a Trade Offer ID? From History?
        // [TestMethod]
        // public async Task GetTradeOfferAsync_Should_Succeed()
        // {
        //     var response = await steamInterface.GetTradeOfferAsync();
        //     Assert.IsNotNull(response);
        //     Assert.IsNotNull(response.Data);
        // }
    }
}
