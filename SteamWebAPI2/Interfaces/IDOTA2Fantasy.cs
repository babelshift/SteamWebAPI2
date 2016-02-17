using System.Threading.Tasks;
using SteamWebAPI2.Models.DOTA2;
using Steam.Models.DOTA2;

namespace SteamWebAPI2.Interfaces
{
    public interface IDOTA2Fantasy
    {
        Task<PlayerOfficialInfoModel> GetPlayerOfficialInfo(long steamId);
        Task<ProPlayerDetailModel> GetProPlayerList();
    }
}