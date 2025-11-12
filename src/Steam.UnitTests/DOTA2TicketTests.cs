using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteamWebAPI2.Interfaces;
using System.Net.Http;

namespace Steam.UnitTests
{
    [TestClass]
    public class DOTA2TicketTests : BaseTest
    {
        private readonly DOTA2Ticket steamInterface;

        public DOTA2TicketTests()
        {
            steamInterface = factory.CreateSteamWebInterface<DOTA2Ticket>(new HttpClient());
        }
    }
}
