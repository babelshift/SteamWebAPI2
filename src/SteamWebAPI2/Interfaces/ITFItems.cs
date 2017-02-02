using Steam.Models.TF2;
using SteamWebAPI2.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface ITFItems
    {
        Task<ISteamWebResponse<IReadOnlyCollection<GoldenWrenchModel>>> GetGoldenWrenchesAsync();
    }
}