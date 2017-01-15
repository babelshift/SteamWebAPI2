using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteamWebAPI2.Interfaces;
using Moq;
using SteamWebAPI2.Utilities;
using SteamWebAPI2.Models.SteamPlayer;
using System.Threading.Tasks;
using SteamWebAPI2.Models.SteamCommunity;

namespace SteamWebAPI2.Tests
{
    [TestClass]
    public class PlayerServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlayerService_Throw_Exception_If_Steam_API_Key_Is_Null_Or_Empty()
        {
            var playerService = new PlayerService(String.Empty);
        }

        [TestMethod]
        public async Task PlayerService_IsPlayingSharedGameAsync_Return_Empty_String_If_Web_Interface_Returns_Null()
        {
            var mockSteamWebRequest = new Mock<ISteamWebInterface>();

            mockSteamWebRequest.Setup(x => x.GetAsync<PlayingSharedGameResultContainer>(It.IsAny<string>(), It.IsAny<int>(), null))
                .ReturnsAsync((PlayingSharedGameResultContainer)null);

            var service = new PlayerService(String.Empty, mockSteamWebRequest.Object);
            var result = await service.IsPlayingSharedGameAsync(0, 0);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, String.Empty);
        }

        [TestMethod]
        public async Task PlayerService_IsPlayingSharedGameAsync_Return_Empty_String_If_Web_Interface_Result_Is_Null()
        {
            var mockSteamWebRequest = new Mock<ISteamWebInterface>();

            mockSteamWebRequest.Setup(x => x.GetAsync<PlayingSharedGameResultContainer>(It.IsAny<string>(), It.IsAny<int>(), null))
                .ReturnsAsync(new PlayingSharedGameResultContainer()
                {
                    Result = null
                });

            var service = new PlayerService(String.Empty, mockSteamWebRequest.Object);
            var result = await service.IsPlayingSharedGameAsync(0, 0);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, String.Empty);
        }

        [TestMethod]
        public async Task PlayerService_GetBadgesAsync_Return_New_If_Web_Request_Is_Null()
        {
            var mockSteamWebRequest = new Mock<ISteamWebInterface>();

            mockSteamWebRequest.Setup(x => x.GetAsync<BadgesResultContainer>(It.IsAny<string>(), It.IsAny<int>(), null))
                .ReturnsAsync((BadgesResultContainer)null);

            var service = new PlayerService(String.Empty, mockSteamWebRequest.Object);
            var result = await service.GetBadgesAsync(0);

            Assert.IsNotNull(result);
            Assert.IsNull(result.Badges);
        }

        [TestMethod]
        public async Task PlayerService_GetCommunityBadgeProgressAsync_Return_Empty_If_Web_Request_Is_Null()
        {
            var mockSteamWebRequest = new Mock<ISteamWebInterface>();

            mockSteamWebRequest.Setup(x => x.GetAsync<CommunityBadgeProgressResultContainer>(It.IsAny<string>(), It.IsAny<int>(), null))
                .ReturnsAsync((CommunityBadgeProgressResultContainer)null);

            var service = new PlayerService(String.Empty, mockSteamWebRequest.Object);
            var result = await service.GetCommunityBadgeProgressAsync(0, 0);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 0);
        }
    }
}
