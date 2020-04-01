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
    public class CSGOServersTests : BaseTest
    {
        [Fact]
        public async Task GetGameServerStatusAsync_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<CSGOServers>(new HttpClient());
            var response = await steamInterface.GetGameServerStatusAsync();
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
    }
}
