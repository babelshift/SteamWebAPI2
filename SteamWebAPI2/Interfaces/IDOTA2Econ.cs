using Steam.Models.DOTA2;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface IDOTA2Econ
    {
        Task<IReadOnlyCollection<GameItemModel>> GetGameItemsAsync(string language = "");

        Task<IReadOnlyCollection<HeroModel>> GetHeroesAsync(string language = "", bool itemizedOnly = false);

        Task<string> GetItemIconPathAsync(string iconName, string iconType = "");

        Task<IReadOnlyCollection<RarityModel>> GetRaritiesAsync(string language = "");

        Task<uint> GetTournamentPrizePoolAsync(uint? leagueId = null);
    }
}