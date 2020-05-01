using Microsoft.Extensions.Configuration;
using SteamWebAPI2.Utilities;
using Microsoft.Extensions.Options;

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

            var factoryOptions = new SteamWebInterfaceFactoryOptions()
            {
                SteamWebApiKey = configuration["SteamWebApiKey"]
            };
            factory = new SteamWebInterfaceFactory(Options.Create(factoryOptions));
        }
    }
}