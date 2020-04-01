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
    public class SteamAppsTests : BaseTest
    {
        private readonly SteamApps steamInterface;

        public SteamAppsTests()
        {
            steamInterface = factory.CreateSteamWebInterface<SteamApps>(new HttpClient());
        }
        
        [Fact]
        public async Task GetAppListAsync_Should_Succeed()
        {
            var response = await steamInterface.GetAppListAsync();
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
        
        [Fact]
        public async Task UpToDateCheckAsync_Should_Succeed()
        {
            var response = await steamInterface.UpToDateCheckAsync(440, 1);
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
    }
}
