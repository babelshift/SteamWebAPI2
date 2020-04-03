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
    public class PlayerServiceTests : BaseTest
    {
        private readonly PlayerService steamInterface;

        public PlayerServiceTests()
        {
            steamInterface = factory.CreateSteamWebInterface<PlayerService>(new HttpClient());
        }
        
        [Fact]
        public async Task IsPlayingSharedGameAsync_Should_Succeed()
        {
            var response = await steamInterface.IsPlayingSharedGameAsync(76561198050013009, 440);
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
        
        [Fact]
        public async Task GetCommunityBadgeProgressAsync_Should_Succeed()
        {
            var response = await steamInterface.GetCommunityBadgeProgressAsync(76561198050013009);
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
        
        [Fact]
        public async Task GetBadgesAsync_Should_Succeed()
        {
            var response = await steamInterface.GetBadgesAsync(76561198050013009);
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
        
        [Fact]
        public async Task GetSteamLevelAsync_Should_Succeed()
        {
            var response = await steamInterface.GetSteamLevelAsync(76561198050013009);
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetOwnedGamesAsync_Should_Succeed()
        {
            var response = await steamInterface.GetOwnedGamesAsync(76561198050013009);
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetRecentlyPlayedGames_Should_Succeed()
        {
            var response = await steamInterface.GetRecentlyPlayedGamesAsync(76561198050013009);
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
    }
}
