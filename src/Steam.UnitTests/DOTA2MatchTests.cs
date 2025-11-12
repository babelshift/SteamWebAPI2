using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteamWebAPI2.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace Steam.UnitTests
{
    [TestClass]
    public class DOTA2MatchTests : BaseTest
    {
        private readonly DOTA2Match steamInterface;

        public DOTA2MatchTests()
        {
            steamInterface = factory.CreateSteamWebInterface<DOTA2Match>(new HttpClient());
        }

        [TestMethod]
        public async Task GetLiveLeagueGamesAsync_Should_Succeed()
        {
            var response = await steamInterface.GetLiveLeagueGamesAsync();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        // This endpoint seems to be broken on Valve's end as of last year. Commenting for now.
        // [TestMethod]
        // public async Task GetMatchDetailsAsync_Should_Succeed()
        // {
        //     var response = await steamInterface.GetMatchDetailsAsync(8555615768);
        //     Assert.IsNotNull(response);
        //     Assert.IsNotNull(response.Data);
        // }

        [TestMethod]
        public async Task GetMatchHistoryAsync_Should_Succeed()
        {
            var response = await steamInterface.GetMatchHistoryAsync();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task GetMatchHistoryBySequenceNumberAsync_Should_Succeed()
        {
            var response = await steamInterface.GetMatchHistoryBySequenceNumberAsync();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task GetTeamInfoByTeamIdAsync_Should_Succeed()
        {
            var response = await steamInterface.GetTeamInfoByTeamIdAsync();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }
    }
}
