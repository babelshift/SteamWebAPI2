using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SteamWebAPI2.Interfaces;
using SteamWebAPI2.Models.SteamCommunity;
using SteamWebAPI2.Models.SteamPlayer;
using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Tests
{
    [TestClass]
    public class PlayerServiceTests
    {
        [TestInitialize]
        public void Initialize()
        {
            AutoMapperConfiguration.Initialize();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlayerService_Throw_Exception_If_Steam_API_Key_Is_Null_Or_Empty()
        {
            var playerService = new PlayerService(String.Empty);
        }

        [TestMethod]
        public async Task PlayerService_IsPlayingSharedGameAsync_Return_Null_If_Web_Interface_Returns_Null()
        {
            var mockSteamWebRequest = new Mock<ISteamWebInterface>();

            mockSteamWebRequest.Setup(x => x.GetAsync<PlayingSharedGameResultContainer>(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<IList<SteamWebRequestParameter>>()))
                .ReturnsAsync((PlayingSharedGameResultContainer)null);

            var service = new PlayerService(String.Empty, mockSteamWebRequest.Object);
            var result = await service.IsPlayingSharedGameAsync(It.IsAny<ulong>(), It.IsAny<uint>());

            Assert.IsTrue(!result.HasValue);
        }

        [TestMethod]
        public async Task PlayerService_IsPlayingSharedGameAsync_Return_Null_If_Web_Interface_Result_Is_Null()
        {
            var mockSteamWebRequest = new Mock<ISteamWebInterface>();

            mockSteamWebRequest.Setup(x => x.GetAsync<PlayingSharedGameResultContainer>(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<IList<SteamWebRequestParameter>>()))
                .ReturnsAsync(new PlayingSharedGameResultContainer()
                {
                    Result = null
                });

            var service = new PlayerService(String.Empty, mockSteamWebRequest.Object);
            var result = await service.IsPlayingSharedGameAsync(It.IsAny<ulong>(), It.IsAny<uint>());

            Assert.IsTrue(!result.HasValue);
        }

        [TestMethod]
        public async Task PlayerService_GetBadgesAsync_Return_Null_If_Web_Interface_Returns_Null()
        {
            var mockSteamWebRequest = new Mock<ISteamWebInterface>();

            mockSteamWebRequest.Setup(x => x.GetAsync<BadgesResultContainer>(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<IList<SteamWebRequestParameter>>()))
                .ReturnsAsync((BadgesResultContainer)null);

            var service = new PlayerService(String.Empty, mockSteamWebRequest.Object);
            var result = await service.GetBadgesAsync(It.IsAny<ulong>());

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task PlayerService_GetBadgesAsync_Return_Null_If_Web_Interface_Result_Is_Null()
        {
            var mockSteamWebRequest = new Mock<ISteamWebInterface>();

            mockSteamWebRequest.Setup(x => x.GetAsync<BadgesResultContainer>(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<IList<SteamWebRequestParameter>>()))
                .ReturnsAsync(new BadgesResultContainer()
                {
                    Result = null
                });

            var service = new PlayerService(String.Empty, mockSteamWebRequest.Object);
            var result = await service.GetBadgesAsync(It.IsAny<ulong>());

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task PlayerService_GetCommunityBadgeProgressAsync_Return_Null_If_Web_Interface_Returns_Null()
        {
            var mockSteamWebRequest = new Mock<ISteamWebInterface>();

            mockSteamWebRequest.Setup(x => x.GetAsync<CommunityBadgeProgressResultContainer>(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<IList<SteamWebRequestParameter>>()))
                .ReturnsAsync((CommunityBadgeProgressResultContainer)null);

            var service = new PlayerService(String.Empty, mockSteamWebRequest.Object);
            var result = await service.GetCommunityBadgeProgressAsync(It.IsAny<uint>(), It.IsAny<uint?>());

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task PlayerService_GetCommunityBadgeProgressAsync_Return_Null_If_Web_Interface_Result_Is_Null()
        {
            var mockSteamWebRequest = new Mock<ISteamWebInterface>();

            mockSteamWebRequest.Setup(x => x.GetAsync<CommunityBadgeProgressResultContainer>(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<IList<SteamWebRequestParameter>>()))
                .ReturnsAsync(new CommunityBadgeProgressResultContainer()
                {
                    Result = null
                });

            var service = new PlayerService(String.Empty, mockSteamWebRequest.Object);
            var result = await service.GetCommunityBadgeProgressAsync(It.IsAny<uint>(), It.IsAny<uint?>());

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task PlayerService_GetSteamLevelAsync_Return_Null_If_Web_Interface_Returns_Null()
        {
            var mockSteamWebRequest = new Mock<ISteamWebInterface>();

            mockSteamWebRequest.Setup(x => x.GetAsync<SteamLevelResultContainer>(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<IList<SteamWebRequestParameter>>()))
                .ReturnsAsync((SteamLevelResultContainer)null);

            var service = new PlayerService(String.Empty, mockSteamWebRequest.Object);
            var result = await service.GetSteamLevelAsync(It.IsAny<uint>());

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task PlayerService_GetSteamLevelAsync_Return_Null_If_Web_Interface_Result_Is_Null()
        {
            var mockSteamWebRequest = new Mock<ISteamWebInterface>();

            mockSteamWebRequest.Setup(x => x.GetAsync<SteamLevelResultContainer>(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<IList<SteamWebRequestParameter>>()))
                .ReturnsAsync(new SteamLevelResultContainer()
                {
                    Result = null
                });

            var service = new PlayerService(String.Empty, mockSteamWebRequest.Object);
            var result = await service.GetSteamLevelAsync(It.IsAny<uint>());

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task PlayerService_GetOwnedGamesAsync_Return_Null_If_Web_Interface_Returns_Null()
        {
            var mockSteamWebRequest = new Mock<ISteamWebInterface>();

            mockSteamWebRequest.Setup(x => x.GetAsync<OwnedGamesResultContainer>(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<IList<SteamWebRequestParameter>>()))
                .ReturnsAsync((OwnedGamesResultContainer)null);

            var service = new PlayerService(String.Empty, mockSteamWebRequest.Object);
            var result = await service.GetOwnedGamesAsync(It.IsAny<ulong>(), It.IsAny<bool?>(), It.IsAny<bool?>(), It.IsAny<IReadOnlyCollection<uint>>());

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task PlayerService_GetOwnedGamesAsync_Return_Null_If_Web_Interface_Result_Is_Null()
        {
            var mockSteamWebRequest = new Mock<ISteamWebInterface>();

            mockSteamWebRequest.Setup(x => x.GetAsync<OwnedGamesResultContainer>(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<IList<SteamWebRequestParameter>>()))
                .ReturnsAsync(new OwnedGamesResultContainer()
                {
                    Result = null
                });

            var service = new PlayerService(String.Empty, mockSteamWebRequest.Object);
            var result = await service.GetOwnedGamesAsync(It.IsAny<ulong>(), It.IsAny<bool?>(), It.IsAny<bool?>(), It.IsAny<IReadOnlyCollection<uint>>());

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task PlayerService_GetOwnedGamesAsync_Trim_Starting_And_Ending_Spaces_From_Owned_Game_Names()
        {
            var mockSteamWebRequest = new Mock<ISteamWebInterface>();

            mockSteamWebRequest.Setup(x => x.GetAsync<OwnedGamesResultContainer>(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<IList<SteamWebRequestParameter>>()))
                .ReturnsAsync(new OwnedGamesResultContainer()
                {
                    Result = new OwnedGamesResult()
                    {
                        GameCount = 10,
                        OwnedGames = new List<OwnedGame>()
                        {
                            new OwnedGame() { Name = "   Test Game 1  " },
                            new OwnedGame() { Name = "   Test Game 2  " },
                            new OwnedGame() { Name = "   Test Game 3  " },
                            new OwnedGame() { Name = "   Test Game 4  " },
                            new OwnedGame() { Name = "   Test Game 5  " },
                        }
                    }
                });

            var service = new PlayerService(String.Empty, mockSteamWebRequest.Object);
            var result = await service.GetOwnedGamesAsync(It.IsAny<ulong>(), It.IsAny<bool?>(), It.IsAny<bool?>(), It.IsAny<IReadOnlyCollection<uint>>());

            // Make sure all game names have been trimmed on the edges
            foreach(var game in result.OwnedGames)
            {
                Assert.IsTrue(!game.Name.StartsWith(" "));
                Assert.IsTrue(!game.Name.EndsWith(" "));
            }
        }

        [TestMethod]
        public async Task PlayerService_GetRecentlyPlayedGamesAsync_Return_Null_If_Web_Interface_Returns_Null()
        {
            var mockSteamWebRequest = new Mock<ISteamWebInterface>();

            mockSteamWebRequest.Setup(x => x.GetAsync<RecentlyPlayedGameResultContainer>(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<IList<SteamWebRequestParameter>>()))
                .ReturnsAsync((RecentlyPlayedGameResultContainer)null);

            var service = new PlayerService(String.Empty, mockSteamWebRequest.Object);
            var result = await service.GetRecentlyPlayedGamesAsync(It.IsAny<ulong>());

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task PlayerService_GetRecentlyPlayedGamesAsync_Return_Null_If_Web_Interface_Result_Is_Null()
        {
            var mockSteamWebRequest = new Mock<ISteamWebInterface>();

            mockSteamWebRequest.Setup(x => x.GetAsync<RecentlyPlayedGameResultContainer>(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<IList<SteamWebRequestParameter>>()))
                .ReturnsAsync(new RecentlyPlayedGameResultContainer()
                {
                    Result = null
                });

            var service = new PlayerService(String.Empty, mockSteamWebRequest.Object);
            var result = await service.GetRecentlyPlayedGamesAsync(It.IsAny<ulong>());

            Assert.IsNull(result);
        }
    }
}