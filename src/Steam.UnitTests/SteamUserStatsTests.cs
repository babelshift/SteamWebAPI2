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
    public class SteamUserStatsTests : BaseTest
    {
        private readonly SteamUserStats steamInterface;

        public SteamUserStatsTests()
        {
            steamInterface = factory.CreateSteamWebInterface<SteamUserStats>(new HttpClient());
        }

        [Fact]
        public async Task GetGlobalAchievementPercentagesForAppAsync_Should_Succeed()
        {
            var response = await steamInterface.GetGlobalAchievementPercentagesForAppAsync(440);
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetGlobalStatsForGameAsync_Should_Succeed()
        {
            List<string> statNames = new List<string>() { "crimefest_challenge_dallas_1" };
            var response = await steamInterface.GetGlobalStatsForGameAsync(218620, statNames.AsReadOnly());
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
        
        [Fact]
        public async Task GetNumberOfCurrentPlayersForGameAsync_Should_Succeed()
        {
            var response = await steamInterface.GetNumberOfCurrentPlayersForGameAsync(440);
            Assert.NotNull(response);
        }
        
        [Fact]
        public async Task GetPlayerAchievementsAsync_Should_Succeed()
        {
            var response = await steamInterface.GetPlayerAchievementsAsync(440, 76561198050013009);
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
        
        [Fact]
        public async Task GetSchemaForGameAsync_Should_Succeed()
        {
            var response = await steamInterface.GetSchemaForGameAsync(440);
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
        
        [Fact]
        public async Task GetUserStatsForGameAsync_Should_Succeed()
        {
            var response = await steamInterface.GetUserStatsForGameAsync(76561198050013009, 440);
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
    }
}
