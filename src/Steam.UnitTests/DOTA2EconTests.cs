using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteamWebAPI2.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace Steam.UnitTests
{
    [TestClass]
    public class DOTA2EconTests : BaseTest
    {
        private readonly DOTA2Econ steamInterface;

        public DOTA2EconTests()
        {
            steamInterface = factory.CreateSteamWebInterface<DOTA2Econ>(new HttpClient());
        }

        [TestMethod]
        public async Task GetHeroesAsync_Should_Succeed()
        {
            var response = await steamInterface.GetHeroesAsync();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task GetRaritiesAsync_Should_Succeed()
        {
            var response = await steamInterface.GetRaritiesAsync();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task GetTournamentPrizePoolAsync_Should_Succeed()
        {
            var response = await steamInterface.GetTournamentPrizePoolAsync();
            Assert.IsNotNull(response);
        }
    }
}
