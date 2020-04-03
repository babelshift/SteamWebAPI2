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
    public class EconServiceTests : BaseTest
    {
        private readonly EconService steamInterface;

        public EconServiceTests()
        {
            steamInterface = factory.CreateSteamWebInterface<EconService>(new HttpClient());
        }

        [Fact]
        public async Task GetPlayerItemsAsync_Should_Succeed()
        {
            var response = await steamInterface.GetTradeHistoryAsync(10);
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetTradeOffersAsync_Should_Succeed()
        {
            var response = await steamInterface.GetTradeOffersAsync(true, true);
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }

        // TODO: Figure out how to get a Trade Offer ID? From History?
        // [Fact]
        // public async Task GetTradeOfferAsync_Should_Succeed()
        // {
        //     var response = await steamInterface.GetTradeOfferAsync();
        //     Assert.NotNull(response);
        //     Assert.NotNull(response.Data);
        // }
    }
}
