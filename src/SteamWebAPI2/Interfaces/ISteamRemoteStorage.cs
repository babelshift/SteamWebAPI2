using Steam.Models;
using SteamWebAPI2.Utilities;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    using System.Collections.Generic;

    public interface ISteamRemoteStorage
    {
        Task<ISteamWebResponse<IReadOnlyCollection<PublishedFileDetailsModel>>> GetPublishedFileDetailsAsync(uint itemCount, IList<ulong> publishedFileIds);

        Task<ISteamWebResponse<IReadOnlyCollection<PublishedFileDetailsModel>>> GetPublishedFileDetailsAsync(IList<ulong> publishedFileIds);

        Task<ISteamWebResponse<PublishedFileDetailsModel>> GetPublishedFileDetailsAsync(ulong publishedFileId);

        Task<ISteamWebResponse<UGCFileDetailsModel>> GetUGCFileDetailsAsync(ulong ugcId, uint appId, ulong? steamId = null);
    }
}