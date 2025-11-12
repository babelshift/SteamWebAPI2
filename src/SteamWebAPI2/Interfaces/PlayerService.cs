using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Steam.Models.SteamCommunity;
using SteamWebAPI2.Models.SteamCommunity;
using SteamWebAPI2.Models.SteamPlayer;
using SteamWebAPI2.Utilities;

namespace SteamWebAPI2.Interfaces
{
    public class PlayerService : IPlayerService
    {
        private readonly ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebRequest"></param>
        public PlayerService(ISteamWebRequest steamWebRequest, ISteamWebInterface steamWebInterface = null)
        {
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface("IPlayerService", steamWebRequest)
                : steamWebInterface;
        }

        /// <summary>
        /// Returns a collection of badge meta data which indicates the progress towards a badge for a specific user.
        /// </summary>
        /// <param name="steamId"></param>
        /// <param name="badgeId"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<BadgeQuestModel>>> GetCommunityBadgeProgressAsync(ulong steamId, uint? badgeId = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(steamId, "steamid");
            parameters.AddIfHasValue(badgeId, "badgeid");

            var steamWebResponse = await steamWebInterface.GetAsync<CommunityBadgeProgressResultContainer>("GetCommunityBadgeProgress", 1, parameters);

            if (steamWebResponse == null)
            {
                return null;
            }

            return steamWebResponse.MapTo<IReadOnlyCollection<BadgeQuestModel>>((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return result.Quests?.Select(q => new BadgeQuestModel
                {
                    QuestId = q.QuestId,
                    Completed = q.Completed
                }).ToList().AsReadOnly();
            });
        }

        /// <summary>
        /// Returns a collection of all badges that a user has interacted with on Steam.
        /// </summary>
        /// <param name="steamId"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<BadgesResultModel>> GetBadgesAsync(ulong steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(steamId, "steamid");

            var steamWebResponse = await steamWebInterface.GetAsync<BadgesResultContainer>("GetBadges", 1, parameters);

            if (steamWebResponse == null)
            {
                return null;
            }

            return steamWebResponse.MapTo((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return new BadgesResultModel
                {
                    Badges = result.Badges?.Select(b => new BadgeModel
                    {
                        BadgeId = b.BadgeId,
                        Level = b.Level,
                        CompletionTime = b.CompletionTime,
                        AppId = b.AppId,
                        BorderColor = b.BorderColor,
                        CommunityItemId = b.CommunityItemId,
                        Scarcity = b.Scarcity,
                        Xp = b.Xp
                    }).ToList().AsReadOnly(),
                    PlayerXp = result.PlayerXp,
                    PlayerLevel = result.PlayerLevel,
                    PlayerXpNeededToLevelUp = result.PlayerXpNeededToLevelUp,
                    PlayerXpNeededCurrentLevel = result.PlayerXpNeededCurrentLevel
                };
            });
        }

        /// <summary>
        /// Returns the Steam Level of a specific Steam User.
        /// </summary>
        /// <param name="steamId"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<uint?>> GetSteamLevelAsync(ulong steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamid");
            var steamWebResponse = await steamWebInterface.GetAsync<SteamLevelResultContainer>("GetSteamLevel", 1, parameters);

            if (steamWebResponse == null)
            {
                return null;
            }

            return steamWebResponse.MapTo((from) =>
            {
                return from?.Result?.PlayerLevel;
            });
        }

        /// <summary>
        /// Returns a collection of games and game meta data that are owned by a specific Steam User.
        /// </summary>
        /// <param name="steamId"></param>
        /// <param name="includeAppInfo"></param>
        /// <param name="includeFreeGames"></param>
        /// <param name="appIdsToFilter"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<OwnedGamesResultModel>> GetOwnedGamesAsync(ulong steamId, bool? includeAppInfo = null, bool? includeFreeGames = null, IReadOnlyCollection<uint> appIdsToFilter = null)
        {
            // translate boolean to 0/1 since that's what the Steam Web API expects
            int? includeAppInfoBit = 0;
            if (includeAppInfo.HasValue) { includeAppInfoBit = includeAppInfo.Value ? 1 : 0; }

            // translate boolean to 0/1 since that's what Steam Web API expects
            int? includeFreeGamesBit = 0;
            if (includeFreeGames.HasValue) { includeFreeGamesBit = includeFreeGames.Value ? 1 : 0; }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            var inputJsonObj = new
            {
                steamid = steamId,
                include_played_Free_games = includeFreeGamesBit,
                include_appinfo = includeAppInfoBit,
                appids_filter = appIdsToFilter
            };
            var inputJson = JsonConvert.SerializeObject(inputJsonObj, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            parameters.AddIfHasValue(WebUtility.UrlEncode(inputJson), "input_json");

            var steamWebResponse = await steamWebInterface.GetAsync<OwnedGamesResultContainer>("GetOwnedGames", 1, parameters);

            if (steamWebResponse == null)
            {
                return null;
            }

            // for some reason, some games have trailing spaces in the result so let's get rid of them
            if (steamWebResponse.Data?.Result?.OwnedGames != null)
            {
                foreach (var ownedGame in steamWebResponse.Data.Result.OwnedGames)
                {
                    if (!string.IsNullOrWhiteSpace(ownedGame.Name))
                    {
                        ownedGame.Name = ownedGame.Name.Trim();
                    }
                }
            }

            return steamWebResponse.MapTo((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return new OwnedGamesResultModel
                {
                    GameCount = result.GameCount,
                    OwnedGames = result.OwnedGames?.Select(g => new OwnedGameModel
                    {
                        AppId = g.AppId,
                        Name = g.Name,
                        PlaytimeForever = TimeSpan.FromMinutes(g.PlaytimeForever),
                        ImgIconUrl = g.ImgIconUrl,
                        ImgLogoUrl = g.ImgLogoUrl,
                        HasCommunityVisibleStats = g.HasCommunityVisibleStats,
                        PlaytimeLastTwoWeeks = g.Playtime2weeks.HasValue
                            ? TimeSpan.FromMinutes(g.Playtime2weeks.Value)
                            : (TimeSpan?)null
                    }).ToList().AsReadOnly()
                };
            });
        }

        /// <summary>
        /// Returns a collection of recently played games and game meta data by a specific Steam User.
        /// </summary>
        /// <param name="steamId"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<RecentlyPlayedGamesResultModel>> GetRecentlyPlayedGamesAsync(ulong steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamid");

            var steamWebResponse = await steamWebInterface.GetAsync<RecentlyPlayedGameResultContainer>("GetRecentlyPlayedGames", 1, parameters);

            if (steamWebResponse == null)
            {
                return null;
            }

            return steamWebResponse.MapTo((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return new RecentlyPlayedGamesResultModel
                {
                    TotalCount = result.TotalCount,
                    RecentlyPlayedGames = result.RecentlyPlayedGames?.Select(g => new RecentlyPlayedGameModel
                    {
                        AppId = g.AppId,
                        Name = g.Name,
                        Playtime2Weeks = g.Playtime2Weeks,
                        PlaytimeForever = g.PlaytimeForever,
                        ImgIconUrl = g.ImgIconUrl,
                        ImgLogoUrl = g.ImgLogoUrl
                    }).ToList().AsReadOnly()
                };
            });
        }
    }
}