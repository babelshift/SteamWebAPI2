using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteamWebAPI2.Interfaces;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace Steam.UnitTests
{
    [TestClass]
    public class SteamUserTests : BaseTest
    {
        private readonly SteamUser steamInterface;

        public SteamUserTests()
        {
            steamInterface = factory.CreateSteamWebInterface<SteamUser>(new HttpClient());
        }

        [TestMethod]
        public async Task GetPlayerSummaryAsync_Should_Succeed()
        {
            var response = await steamInterface.GetPlayerSummaryAsync(76561198050013009);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task GetPlayerSummariesAsync_Should_Succeed()
        {
            List<ulong> steamIds = new List<ulong>() { 76561198050013009 };
            var response = await steamInterface.GetPlayerSummariesAsync(steamIds.AsReadOnly());
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task GetFriendsListAsync_Should_Succeed()
        {
            var response = await steamInterface.GetFriendsListAsync(76561198050013009);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task GetPlayerBansAsync_Should_Succeed()
        {
            var response = await steamInterface.GetPlayerBansAsync(76561198050013009);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task GetPlayerBansMultipleAsync_Should_Succeed()
        {
            List<ulong> steamIds = new List<ulong>() { 76561198050013009 };
            var response = await steamInterface.GetPlayerBansAsync(steamIds.AsReadOnly());
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task GetUserGroupsAsync_Should_Succeed()
        {
            var response = await steamInterface.GetUserGroupsAsync(76561198050013009);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task ResolveVanityUrlAsync_Should_Succeed()
        {
            var response = await steamInterface.ResolveVanityUrlAsync("aro");
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Data > 0);
        }

        [TestMethod]
        public async Task GetCommunityProfileAsync_Should_Succeed()
        {
            //for other cultures (for example ru) automaper will not be able to convert floating point numbers and will throw an error
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("en");
            var response = await steamInterface.GetCommunityProfileAsync(76561198064401017);
            Assert.IsNotNull(response);
        }
    }
}
