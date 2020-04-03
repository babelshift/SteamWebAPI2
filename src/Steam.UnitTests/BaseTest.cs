using Microsoft.Extensions.Configuration;
using SteamWebAPI2.Utilities;

namespace Steam.UnitTests
{
    public class BaseTest
    {
        private IConfiguration configuration;
        protected readonly SteamWebInterfaceFactory factory;

        public BaseTest()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<CSGOServersTests>();
            configuration = builder.Build();

            factory = new SteamWebInterfaceFactory(configuration["SteamWebApiKey"]);
        }
    }
}