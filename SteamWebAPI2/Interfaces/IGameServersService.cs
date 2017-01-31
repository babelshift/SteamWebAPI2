using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface IGameServersService
    {
        Task<dynamic> GetAccountListAsync();

        Task<dynamic> CreateAccount(uint appid, string memo);

        Task<dynamic> SetMemo(ulong steamId, string memo);

        Task<dynamic> ResetLoginToken(ulong steamId);

        Task<dynamic> DeleteAccount(ulong steamId);

        Task<dynamic> GetAccountPublicInfo(ulong steamId);

        Task<dynamic> QueryLoginToken(string loginToken);

        Task<dynamic> GetServerSteamIDsByIP(IReadOnlyCollection<string> serverIPs);

        Task<dynamic> GetServerIPsBySteamID(IReadOnlyCollection<ulong> steamIds);
    }
}