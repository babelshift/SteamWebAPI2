using System.Threading.Tasks;
using SteamWebAPI2.Models.DOTA2;

namespace SteamWebAPI2.Interfaces
{
    public interface IDOTA2Fantasy
    {
        Task<PlayerOfficialInfoResult> GetPlayerOfficialInfo(long steamId);
        Task<ProPlayerListResult> GetProPlayerList();
    }
}