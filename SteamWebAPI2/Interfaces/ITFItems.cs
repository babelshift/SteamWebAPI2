using Steam.Models.TF2;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface ITFItems
    {
        Task<IReadOnlyCollection<GoldenWrenchModel>> GetGoldenWrenchesAsync();
    }
}