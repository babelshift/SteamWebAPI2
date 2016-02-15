using Steam.Models.TF2;
using SteamWebAPI2.Models.TF2;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class TFItems : SteamWebInterface, ITFItems
    {
        public TFItems(string steamWebApiKey)
            : base(steamWebApiKey, "ITFItems_440")
        {
        }

        public async Task<IReadOnlyCollection<GoldenWrenchModel>> GetGoldenWrenchesAsync()
        {
            var goldenWrenchesResult = await CallMethodAsync<GoldenWrenchResultContainer>("GetGoldenWrenches", 2);

            var goldenWrenchModels = AutoMapperConfiguration.Mapper.Map<IList<GoldenWrench>, IList<GoldenWrenchModel>>(goldenWrenchesResult.Result.GoldenWrenches);

            return new ReadOnlyCollection<GoldenWrenchModel>(goldenWrenchModels);
        }
    }
}