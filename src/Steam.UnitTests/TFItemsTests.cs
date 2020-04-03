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
    public class TFItemsTests : BaseTest
    {
        private readonly TFItems steamInterface;

        public TFItemsTests()
        {
            steamInterface = factory.CreateSteamWebInterface<TFItems>(new HttpClient());
        }

        [Fact]
        public async Task GetServerInfoAsync_Should_Succeed()
        {
            var response = await steamInterface.GetGoldenWrenchesAsync();
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
    }
}
