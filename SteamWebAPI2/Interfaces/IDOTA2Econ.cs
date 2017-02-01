using Steam.Models.DOTA2;
using SteamWebAPI2.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface IDOTA2Econ
    {
        Task<ISteamWebResponse<IReadOnlyCollection<GameItemModel>>> GetGameItemsAsync(string language = "");

        Task<ISteamWebResponse<IReadOnlyCollection<HeroModel>>> GetHeroesAsync(string language = "", bool itemizedOnly = false);

        Task<ISteamWebResponse<string>> GetItemIconPathAsync(string iconName, string iconType = "");

        Task<ISteamWebResponse<IReadOnlyCollection<RarityModel>>> GetRaritiesAsync(string language = "");

        Task<ISteamWebResponse<uint>> GetTournamentPrizePoolAsync(uint? leagueId = null);
    }
}