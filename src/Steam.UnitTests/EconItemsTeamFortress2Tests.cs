using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteamWebAPI2.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace Steam.UnitTests
{
    [TestClass]
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

        [TestMethod]
        public async Task GetSchemaItemsForTF2Async_Should_Succeed()
        {
            uint? next = null;

            do
            {
                var response = await steamInterface.GetSchemaItemsForTF2Async(start: next);
                Assert.IsNotNull(response);
                Assert.IsNotNull(response.Data);

                next = response.Data.Result.Next;
            }
            while (next.HasValue);
        }

        [TestMethod]
        public async Task GetSchemaOverviewForTF2Async_Should_Succeed()
        {
            var response = await steamInterface.GetSchemaOverviewForTF2Async();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task GetSchemaUrlAsync_Should_Succeed()
        {
            var response = await steamInterface.GetSchemaUrlAsync();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task GetStoreMetaDataAsync_Should_Succeed()
        {
            var response = await steamInterface.GetStoreMetaDataAsync();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task GetStoreStatusAsync_Should_Succeed()
        {
            var response = await steamInterface.GetStoreStatusAsync();
            Assert.IsNotNull(response);
        }
    }
}
