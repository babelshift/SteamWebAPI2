using SteamWebAPI2.Interfaces;
using System.Net.Http;
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
                AppId.TeamFortress2,
                new HttpClient()
            );
        }

        [Fact]
        public async Task GetSchemaItemsForTF2Async_Should_Succeed()
        {
            uint? next = null;

            do
            {
                var response = await steamInterface.GetSchemaItemsForTF2Async(start: next);
                Assert.NotNull(response);
                Assert.NotNull(response.Data);

                next = response.Data.Result.Next;
            }
            while (next.HasValue);
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
