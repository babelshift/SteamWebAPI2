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
    public class DOTA2MatchTests : BaseTest
    {
        private readonly DOTA2Match steamInterface;

        public DOTA2MatchTests()
        {
            steamInterface = factory.CreateSteamWebInterface<DOTA2Match>(new HttpClient());
        }

        [Fact]
        public async Task GetLiveLeagueGamesAsync_Should_Succeed()
        {
            var response = await steamInterface.GetLiveLeagueGamesAsync();
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetMatchDetailsAsync_Should_Succeed()
        {
            var response = await steamInterface.GetMatchDetailsAsync(5327512468);
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetMatchHistoryAsync_Should_Succeed()
        {
            var response = await steamInterface.GetMatchHistoryAsync();
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
        
        [Fact]
        public async Task GetMatchHistoryBySequenceNumberAsync_Should_Succeed()
        {
            var response = await steamInterface.GetMatchHistoryBySequenceNumberAsync();
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
        
        [Fact]
        public async Task GetTeamInfoByTeamIdAsync_Should_Succeed()
        {
            var response = await steamInterface.GetTeamInfoByTeamIdAsync();
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
    }
}
