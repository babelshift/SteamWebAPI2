using AutoMapper;
using SteamWebAPI2.Interfaces;
using SteamWebAPI2.Mappings;
using System.Threading.Tasks;
using Xunit;

namespace Steam.UnitTests
{
    public class SteamStoreTests
    {
        private readonly SteamStore steamStore;

        public SteamStoreTests()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<SteamStoreProfile>();
            });

            var mapper = mapperConfig.CreateMapper();

            steamStore = new SteamStore(mapper);
        }
        
        [Fact]
        public async Task GetStoreAppDetailsAsync_Should_Succeed()
        {
            var response = await steamStore.GetStoreAppDetailsAsync(1086940);
            Assert.NotNull(response);
            Assert.NotNull(response.Name);
        }

        [Fact]
        public async Task GetStoreAppDetailsAsync_WithCurrency_Should_Succeed()
        {
            var response = await steamStore.GetStoreAppDetailsAsync(1086940, "mx");
            Assert.NotNull(response);
            Assert.NotNull(response.PriceOverview?.Currency);
            Assert.Equal("MXN", response.PriceOverview.Currency);
        }

        [Fact]
        public async Task GetStoreAppDetailsAsync_WithLanguage_Should_Succeed()
        {
            var response = await steamStore.GetStoreAppDetailsAsync(1086940, "german");
            Assert.NotNull(response);
            Assert.NotNull(response.Name);
        }
    }
}
