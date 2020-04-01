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
    public class EconItemsTeamFortress2Tests : BaseTest
    {
        private readonly EconItems steamInterface;

        public EconItemsTeamFortress2Tests()
        {
            steamInterface = factory.CreateSteamWebInterface<EconItems>(
                new HttpClient(), 
                EconItemsAppId.TeamFortress2
            );
        }

        [Fact]
        public async Task GetPlayerItemsAsync_Should_Succeed()
        {
            var response = await steamInterface.GetPlayerItemsAsync(76561198050013009);
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
        
        [Fact]
        public async Task GetSchemaItemsForTF2Async_Should_Succeed()
        {
            var response = await steamInterface.GetSchemaItemsForTF2Async();
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
        
        [Fact]
        public async Task GetSchemaOverviewForTF2Async_Should_Succeed()
        {
            var response = await steamInterface.GetSchemaOverviewForTF2Async();
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
        
        [Fact]
        public async Task GetSchemaUrlAsync_Should_Succeed()
        {
            var response = await steamInterface.GetSchemaUrlAsync();
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
        
        [Fact]
        public async Task GetStoreMetaDataAsync_Should_Succeed()
        {
            var response = await steamInterface.GetStoreMetaDataAsync();
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
        
        [Fact]
        public async Task GetStoreStatusAsync_Should_Succeed()
        {
            var response = await steamInterface.GetStoreStatusAsync();
            Assert.NotNull(response);
        }
    }
}
