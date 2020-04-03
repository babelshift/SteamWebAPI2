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
    public class DOTA2TicketTests : BaseTest
    {
        private readonly DOTA2Ticket steamInterface;

        public DOTA2TicketTests()
        {
            steamInterface = factory.CreateSteamWebInterface<DOTA2Ticket>(new HttpClient());
        }
    }
}
