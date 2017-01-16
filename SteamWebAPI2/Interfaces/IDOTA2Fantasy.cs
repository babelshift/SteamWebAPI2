using Steam.Models.DOTA2;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface IDOTA2Fantasy
    {
        Task<PlayerOfficialInfoModel> GetPlayerOfficialInfo(ulong steamId);

        Task<ProPlayerDetailModel> GetProPlayerList();
    }
}