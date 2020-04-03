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
    public class SteamEconomyTests : BaseTest
    {
        private readonly SteamEconomy steamInterface;

        public SteamEconomyTests()
        {
            steamInterface = factory.CreateSteamWebInterface<SteamEconomy>(new HttpClient());
        }
        
        [Fact]
        public async Task GetAssetClassInfoAsync_Should_Succeed()
        {
            List<ulong> classes = new List<ulong>() { 211447708 };
            var response = await steamInterface.GetAssetClassInfoAsync(440, classes);
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
        
        [Fact]
        public async Task GetAssetPricesAsync_Should_Succeed()
        {
            var response = await steamInterface.GetAssetPricesAsync(440);
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
    }
}
