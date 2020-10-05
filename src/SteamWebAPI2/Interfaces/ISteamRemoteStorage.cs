using Steam.Models;
using SteamWebAPI2.Models;
using SteamWebAPI2.Utilities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamRemoteStorage
    {
        Task<ISteamWebResponse<IReadOnlyCollection<CollectionDetail>>> GetCollectionDetails(ulong collectionId);

        Task<ISteamWebResponse<IReadOnlyCollection<CollectionDetail>>> GetCollectionDetails(IList<ulong> collectionId);

        Task<ISteamWebResponse<IReadOnlyCollection<PublishedFileDetailsModel>>> GetPublishedFileDetailsAsync(uint itemCount, IList<ulong> publishedFileIds);

        Task<ISteamWebResponse<IReadOnlyCollection<PublishedFileDetailsModel>>> GetPublishedFileDetailsAsync(IList<ulong> publishedFileIds);

        Task<ISteamWebResponse<PublishedFileDetailsModel>> GetPublishedFileDetailsAsync(ulong publishedFileId);

        Task<ISteamWebResponse<UGCFileDetailsModel>> GetUGCFileDetailsAsync(ulong ugcId, uint appId, ulong? steamId = null);
    }
}