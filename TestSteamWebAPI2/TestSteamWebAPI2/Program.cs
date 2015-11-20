using SteamWebAPI2;
using SteamWebAPI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSteamWebAPI2
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                SteamWebSession session = new SteamWebSession("8D06823474AB641C684EBD95AB5F2E49");
                var list = await session.GetPlayerSummary("76561197960361544");
                int i = 0;
            }).Wait();

            Console.ReadLine();
        }
    }
}
