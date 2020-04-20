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
            
            steamInterfaceCounterStrikeGO= factory.CreateSteamWebInterface<GCVersion>(
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
        
        [Fact]
        public async Task GetClientVersionTeamFortress2Async_Should_Succeed()
        {
            var response = await steamInterfaceTeamFortress2.GetClientVersionAsync();
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
        
        [Fact]
        public async Task GetServerVersionTeamFortress2Async_Should_Succeed()
        {
            var response = await steamInterfaceTeamFortress2.GetServerVersionAsync();
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetClientVersionCounterStrikeGOAsync_Should_Fail()
        {
            await Assert.ThrowsAsync<InvalidOperationException>(() => 
                steamInterfaceCounterStrikeGO.GetClientVersionAsync()
            );
        }
        
        [Fact]
        public async Task GetServerVersionCounterStrikeGOAsync_Should_Succeed()
        {
            var response = await steamInterfaceCounterStrikeGO.GetServerVersionAsync();
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetClientVersionDota2Async_Should_Succeed()
        {
            var response = await steamInterfaceDota2.GetClientVersionAsync();
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
        
        [Fact]
        public async Task GetServerVersionDota2Async_Should_Succeed()
        {
            var response = await steamInterfaceDota2.GetServerVersionAsync();
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetClientVersionArtifactAsync_Should_Succeed()
        {
            var response = await steamInterfaceArtifact.GetClientVersionAsync();
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
        
        [Fact]
        public async Task GetServerVersionArtifactAsync_Should_Succeed()
        {
            var response = await steamInterfaceArtifact.GetServerVersionAsync();
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetClientVersionDotaUnderlordsAsync_Should_Succeed()
        {
            var response = await steamInterfaceDotaUnderlords.GetClientVersionAsync();
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
        
        [Fact]
        public async Task GetServerVersionDotaUnderlordsAsync_Should_Succeed()
        {
            var response = await steamInterfaceDotaUnderlords.GetServerVersionAsync();
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
    }
}
