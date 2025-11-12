using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteamWebAPI2.Interfaces;
using SteamWebAPI2.Utilities;
using System;
using System.Net.Http;

namespace Steam.UnitTests
{
    [TestClass]
    public class SteamWebInterfaceFactoryTests
    {
        private readonly SteamWebInterfaceFactory factory;

        public SteamWebInterfaceFactoryTests()
        {
            var factoryOptions = new SteamWebInterfaceFactoryOptions()
            {
                SteamWebApiKey = "ABC123"
            };
            factory = new SteamWebInterfaceFactory(Options.Create(factoryOptions));
        }

        [TestMethod]
        public void Constructor_Should_Succeed()
        {
            var factoryOptions = new SteamWebInterfaceFactoryOptions()
            {
                SteamWebApiKey = "ABC123"
            };
            var factory = new SteamWebInterfaceFactory(Options.Create(factoryOptions));
            Assert.IsNotNull(factory);
        }

        [TestMethod]
        public void Constructor_Should_Fail_If_Empty_Key()
        {
            var factoryOptions = new SteamWebInterfaceFactoryOptions()
            {
                SteamWebApiKey = ""
            };
            Assert.ThrowsException<ArgumentNullException>(() => new SteamWebInterfaceFactory(Options.Create(factoryOptions)));
        }

        [TestMethod]
        public void Constructor_Should_Fail_If_Null_Key()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new SteamWebInterfaceFactory(steamWebApiKey: null));
        }

        [TestMethod]
        public void Create_SteamUser_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<SteamUser>(new HttpClient());
            Assert.IsNotNull(steamInterface);
        }

        [TestMethod]
        public void Create_CSGOServers_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<CSGOServers>(new HttpClient());
            Assert.IsNotNull(steamInterface);
        }

        [TestMethod]
        public void Create_DOTA2Econ_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<DOTA2Econ>(new HttpClient());
            Assert.IsNotNull(steamInterface);
        }

        [TestMethod]
        public void Create_DOTA2Match_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<DOTA2Match>();
            Assert.IsNotNull(steamInterface);
        }

        [TestMethod]
        public void Create_DOTA2Ticket_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<DOTA2Ticket>();
            Assert.IsNotNull(steamInterface);
        }

        [TestMethod]
        public void Create_EconItems_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<EconItems>(AppId.TeamFortress2);
            Assert.IsNotNull(steamInterface);
        }

        [TestMethod]
        public void Create_EconService_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<EconService>();
            Assert.IsNotNull(steamInterface);
        }

        [TestMethod]
        public void Create_GameServersService_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<GameServersService>();
            Assert.IsNotNull(steamInterface);
        }

        [TestMethod]
        public void Create_GCVersion_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<GCVersion>(AppId.TeamFortress2);
            Assert.IsNotNull(steamInterface);
        }

        [TestMethod]
        public void Create_PlayerService_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<PlayerService>();
            Assert.IsNotNull(steamInterface);
        }

        [TestMethod]
        public void Create_SteamApps_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<SteamApps>();
            Assert.IsNotNull(steamInterface);
        }

        [TestMethod]
        public void Create_SteamEconomy_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<SteamEconomy>();
            Assert.IsNotNull(steamInterface);
        }

        [TestMethod]
        public void Create_SteamNews_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<SteamNews>();
            Assert.IsNotNull(steamInterface);
        }

        [TestMethod]
        public void Create_SteamRemoteStorage_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<SteamRemoteStorage>();
            Assert.IsNotNull(steamInterface);
        }

        [TestMethod]
        public void Create_SteamStore_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamStoreInterface();
            Assert.IsNotNull(steamInterface);
        }

        [TestMethod]
        public void Create_SteamUserAuth_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<SteamUserAuth>();
            Assert.IsNotNull(steamInterface);
        }

        [TestMethod]
        public void Create_SteamUserStats_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<SteamUserStats>();
            Assert.IsNotNull(steamInterface);
        }

        [TestMethod]
        public void Create_SteamWebAPIUtil_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<SteamWebAPIUtil>();
            Assert.IsNotNull(steamInterface);
        }
    }
}