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
    public class SteamUserTests : BaseTest
    {
        private readonly SteamUser steamInterface;

        public SteamUserTests()
        {
            steamInterface = factory.CreateSteamWebInterface<SteamUser>(new HttpClient());
        }

        [Fact]
        public async Task GetPlayerSummaryAsync_Should_Succeed()
        {
            var response = await steamInterface.GetPlayerSummaryAsync(76561198050013009);
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetPlayerSummariesAsync_Should_Succeed()
        {
            List<ulong> steamIds = new List<ulong>() { 76561198050013009 };
            var response = await steamInterface.GetPlayerSummariesAsync(steamIds.AsReadOnly());
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetFriendsListAsync_Should_Succeed()
        {
            var response = await steamInterface.GetFriendsListAsync(76561198050013009);
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetPlayerBansAsync_Should_Succeed()
        {
            var response = await steamInterface.GetPlayerBansAsync(76561198050013009);
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetPlayerBansMultipleAsync_Should_Succeed()
        {
            List<ulong> steamIds = new List<ulong>() { 76561198050013009 };
            var response = await steamInterface.GetPlayerBansAsync(steamIds.AsReadOnly());
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetUserGroupsAsync_Should_Succeed()
        {
            var response = await steamInterface.GetUserGroupsAsync(76561198050013009);
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task ResolveVanityUrlAsync_Should_Succeed()
        {
            var response = await steamInterface.ResolveVanityUrlAsync("aro");
            Assert.NotNull(response);
            Assert.True(response.Data > 0);
        }

        [Fact]
        public async Task GetCommunityProfileAsync_Should_Succeed()
        {
            var response = await steamInterface.GetCommunityProfileAsync(76561198050013009);
            Assert.NotNull(response);
        }
    }
}
