using Steam.Models.DOTA2;
using SteamWebAPI2.Utilities;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface IDOTA2Fantasy
    {
        Task<ISteamWebResponse<PlayerOfficialInfoModel>> GetPlayerOfficialInfo(ulong steamId);

        Task<ISteamWebResponse<ProPlayerDetailModel>> GetProPlayerList();
    }
}