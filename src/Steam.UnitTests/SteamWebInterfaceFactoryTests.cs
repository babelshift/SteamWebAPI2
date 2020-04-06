﻿using SteamWebAPI2.Interfaces;
using SteamWebAPI2.Utilities;
using System;
using System.Net.Http;
using Xunit;

namespace Steam.UnitTests
{
    public class SteamWebInterfaceFactoryTests
    {
        private readonly SteamWebInterfaceFactory factory = new SteamWebInterfaceFactory("ABC123");

        [Fact]
        public void Constructor_Should_Succeed()
        {
            var factory = new SteamWebInterfaceFactory("ABC123");
            Assert.NotNull(factory);
        }

        [Fact]
        public void Constructor_Should_Fail_If_Empty_Key()
        {
            Assert.Throws<ArgumentNullException>(() => new SteamWebInterfaceFactory(""));
        }

        [Fact]
        public void Constructor_Should_Fail_If_Null_Key()
        {
            Assert.Throws<ArgumentNullException>(() => new SteamWebInterfaceFactory(null));
        }

        [Fact]
        public void Create_SteamUser_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<SteamUser>(new HttpClient());
            Assert.NotNull(steamInterface);
        }

        [Fact]
        public void Create_CSGOServers_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<CSGOServers>(new HttpClient());
            Assert.NotNull(steamInterface);
        }

        [Fact]
        public void Create_DOTA2Econ_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<DOTA2Econ>(new HttpClient());
            Assert.NotNull(steamInterface);
        }

        [Fact]
        public void Create_DOTA2Match_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<DOTA2Match>();
            Assert.NotNull(steamInterface);
        }

        [Fact]
        public void Create_DOTA2Ticket_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<DOTA2Ticket>();
            Assert.NotNull(steamInterface);
        }

        [Fact]
        public void Create_EconItems_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<EconItems>(EconItemsAppId.TeamFortress2);
            Assert.NotNull(steamInterface);
        }

        [Fact]
        public void Create_EconService_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<EconService>();
            Assert.NotNull(steamInterface);
        }

        [Fact]
        public void Create_GameServersService_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<GameServersService>();
            Assert.NotNull(steamInterface);
        }

        [Fact]
        public void Create_GCVersion_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<GCVersion>(GCVersionAppId.TeamFortress2);
            Assert.NotNull(steamInterface);
        }

        [Fact]
        public void Create_PlayerService_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<PlayerService>();
            Assert.NotNull(steamInterface);
        }

        [Fact]
        public void Create_SteamApps_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<SteamApps>();
            Assert.NotNull(steamInterface);
        }

        [Fact]
        public void Create_SteamEconomy_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<SteamEconomy>();
            Assert.NotNull(steamInterface);
        }

        [Fact]
        public void Create_SteamNews_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<SteamNews>();
            Assert.NotNull(steamInterface);
        }

        [Fact]
        public void Create_SteamRemoteStorage_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<SteamRemoteStorage>();
            Assert.NotNull(steamInterface);
        }

        [Fact]
        public void Create_SteamStore_Interface_Should_Succeed()
        {
            var steamInterface = new SteamStore();
            Assert.NotNull(steamInterface);
        }

        [Fact]
        public void Create_SteamUserAuth_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<SteamUserAuth>();
            Assert.NotNull(steamInterface);
        }

        [Fact]
        public void Create_SteamUserStats_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<SteamUserStats>();
            Assert.NotNull(steamInterface);
        }

        [Fact]
        public void Create_SteamWebAPIUtil_Interface_Should_Succeed()
        {
            var steamInterface = factory.CreateSteamWebInterface<SteamWebAPIUtil>();
            Assert.NotNull(steamInterface);
        }
    }
}