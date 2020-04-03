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
    public class SteamWebAPIUtilTests : BaseTest
    {
        private readonly SteamWebAPIUtil steamInterface;

        public SteamWebAPIUtilTests()
        {
            steamInterface = factory.CreateSteamWebInterface<SteamWebAPIUtil>(new HttpClient());
        }

        [Fact]
        public async Task GetServerInfoAsync_Should_Succeed()
        {
            var response = await steamInterface.GetServerInfoAsync();
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetSupportedAPIListAsync_Should_Succeed()
        {
            var response = await steamInterface.GetSupportedAPIListAsync();
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
    }
}
