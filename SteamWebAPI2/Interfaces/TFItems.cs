using SteamWebAPI2.Models.TF2;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class TFItems : SteamWebInterface
    {
        public TFItems(string steamWebApiKey)
            : base(steamWebApiKey, "ITFItems_440")
        {
        }

        public async Task<IReadOnlyCollection<GoldenWrench>> GetGoldenWrenchesAsync()
        {
            var goldenWrenchesResult = await CallMethodAsync<GoldenWrenchResultContainer>("GetGoldenWrenches", 2);
            return new ReadOnlyCollection<GoldenWrench>(goldenWrenchesResult.Result.GoldenWrenches);
        }
    }
}