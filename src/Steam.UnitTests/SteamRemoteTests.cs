using Microsoft.VisualStudio.TestTools.UnitTesting;
using Steam.Models;
using SteamWebAPI2.Interfaces;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Steam.UnitTests
{
    [TestClass]
    public class SteamRemoteTests : BaseTest
    {
        private readonly SteamRemoteStorage steamInterface;

        public SteamRemoteTests()
        {
            steamInterface = factory.CreateSteamWebInterface<SteamRemoteStorage>(new HttpClient());
        }

        [TestMethod]
        public async Task GetPublishedFileDetailsAsync_Public_Visibility_Should_Succeed()
        {
            var response = await steamInterface.GetPublishedFileDetailsAsync(1673456286);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
            Assert.AreEqual(PublishedFileVisibility.Public, response.Data.FirstOrDefault()?.Visibility);
        }

        [TestMethod]
        public async Task GetPublishedFileDetailsAsync_Unknown_Visibility_Should_Succeed()
        {
            var response = await steamInterface.GetPublishedFileDetailsAsync(2097579725);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
            Assert.AreEqual(PublishedFileVisibility.Unknown, response.Data.FirstOrDefault()?.Visibility);
        }
    }
}
