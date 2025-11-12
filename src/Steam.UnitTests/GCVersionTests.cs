using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteamWebAPI2.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Steam.UnitTests
{
    [TestClass]
    public class GCVersionTests : BaseTest
    {
        private readonly GCVersion steamInterfaceTeamFortress2;
        private readonly GCVersion steamInterfaceCounterStrikeGO;
        private readonly GCVersion steamInterfaceDota2;
        private readonly GCVersion steamInterfaceArtifact;
        private readonly GCVersion steamInterfaceDotaUnderlords;

        public GCVersionTests()
        {
            HttpClient httpClient = new HttpClient();

            steamInterfaceTeamFortress2 = factory.CreateSteamWebInterface<GCVersion>(
                AppId.TeamFortress2,
                httpClient
            );

            steamInterfaceCounterStrikeGO = factory.CreateSteamWebInterface<GCVersion>(
                AppId.CounterStrikeGO,
                httpClient
            );

            steamInterfaceDota2 = factory.CreateSteamWebInterface<GCVersion>(
                AppId.Dota2,
                httpClient
            );

            steamInterfaceArtifact = factory.CreateSteamWebInterface<GCVersion>(
                AppId.Artifact,
                httpClient
            );

            steamInterfaceDotaUnderlords = factory.CreateSteamWebInterface<GCVersion>(
                AppId.DotaUnderlords,
                httpClient
            );
        }

        [TestMethod]
        public async Task GetClientVersionTeamFortress2Async_Should_Succeed()
        {
            var response = await steamInterfaceTeamFortress2.GetClientVersionAsync();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task GetServerVersionTeamFortress2Async_Should_Succeed()
        {
            var response = await steamInterfaceTeamFortress2.GetServerVersionAsync();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task GetClientVersionCounterStrikeGOAsync_Should_Fail()
        {
            await Assert.ThrowsExceptionAsync<InvalidOperationException>(() =>
                steamInterfaceCounterStrikeGO.GetClientVersionAsync()
            );
        }

        [TestMethod]
        public async Task GetServerVersionCounterStrikeGOAsync_Should_Succeed()
        {
            var response = await steamInterfaceCounterStrikeGO.GetServerVersionAsync();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task GetClientVersionDota2Async_Should_Succeed()
        {
            var response = await steamInterfaceDota2.GetClientVersionAsync();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task GetServerVersionDota2Async_Should_Succeed()
        {
            var response = await steamInterfaceDota2.GetServerVersionAsync();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task GetClientVersionArtifactAsync_Should_Succeed()
        {
            var response = await steamInterfaceArtifact.GetClientVersionAsync();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task GetServerVersionArtifactAsync_Should_Succeed()
        {
            var response = await steamInterfaceArtifact.GetServerVersionAsync();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task GetClientVersionDotaUnderlordsAsync_Should_Succeed()
        {
            var response = await steamInterfaceDotaUnderlords.GetClientVersionAsync();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task GetServerVersionDotaUnderlordsAsync_Should_Succeed()
        {
            var response = await steamInterfaceDotaUnderlords.GetServerVersionAsync();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }
    }
}
