using Microsoft.Extensions.Configuration;
using SteamWebAPI2.Interfaces;
using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Steam.UnitTests
{
    public class DOTA2EconTests : BaseTest
    {
        private readonly DOTA2Econ steamInterface;

        public DOTA2EconTests()
        {
            steamInterface = factory.CreateSteamWebInterface<DOTA2Econ>(new HttpClient());
        }

        [Fact]
        public async Task GetGameItemsAsync_Should_Succeed()
        {
            var response = await steamInterface.GetGameItemsAsync();
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetHeroesAsync_Should_Succeed()
        {
            var response = await steamInterface.GetHeroesAsync();
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetRaritiesAsync_Should_Succeed()
        {
            var response = await steamInterface.GetRaritiesAsync();
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetTournamentPrizePoolAsync_Should_Succeed()
        {
            var response = await steamInterface.GetTournamentPrizePoolAsync();
            Assert.NotNull(response);
        }
    }
}
