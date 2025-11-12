
using Steam.Models.SteamCommunity;
using SteamWebAPI2.Exceptions;
using SteamWebAPI2.Models.SteamCommunity;
using SteamWebAPI2.Models.SteamPlayer;
using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class SteamUser : ISteamUser
    {
        private readonly ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebRequest"></param>
        public SteamUser(ISteamWebRequest steamWebRequest, ISteamWebInterface steamWebInterface = null)
        {
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface("ISteamUser", steamWebRequest)
                : steamWebInterface;
        }

        /// <summary>
        /// Returns a summary of some player and Steam User information such as their Steam Profile data.
        /// </summary>
        /// <param name="steamId"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<PlayerSummaryModel>> GetPlayerSummaryAsync(ulong steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamids");

            var steamWebResponse = await steamWebInterface.GetAsync<PlayerSummaryResultContainer>("GetPlayerSummaries", 2, parameters);

            if (steamWebResponse == null
                || steamWebResponse.Data == null
                || steamWebResponse.Data.Result == null
                || steamWebResponse.Data.Result.Players == null
                || steamWebResponse.Data.Result.Players.Count == 0)
            {
                return null;
            }

            return steamWebResponse.MapTo((from) =>
            {
                var players = from?.Result?.Players;
                if (players == null || players.Count == 0)
                {
                    return null;
                }

                var p = players[0];

                return new PlayerSummaryModel
                {
                    SteamId = p.SteamId,
                    ProfileVisibility = p.ProfileVisibility,
                    ProfileState = p.ProfileState,
                    Nickname = p.Nickname,
                    LastLoggedOffDate = p.LastLoggedOffDate,
                    CommentPermission = p.CommentPermission,
                    ProfileUrl = p.ProfileUrl,
                    AvatarUrl = p.AvatarUrl,
                    AvatarMediumUrl = p.AvatarMediumUrl,
                    AvatarFullUrl = p.AvatarFullUrl,
                    UserStatus = p.UserStatus,
                    RealName = p.RealName,
                    PrimaryGroupId = p.PrimaryGroupId,
                    AccountCreatedDate = p.AccountCreatedDate,
                    CountryCode = p.CountryCode,
                    StateCode = p.StateCode,
                    CityCode = p.CityCode,
                    PlayingGameName = p.PlayingGameName,
                    PlayingGameId = p.PlayingGameId,
                    PlayingGameServerIP = p.PlayingGameServerIP
                };
            });
        }

        public async Task<ISteamWebResponse<IReadOnlyCollection<PlayerSummaryModel>>> GetPlayerSummariesAsync(IReadOnlyCollection<ulong> steamIds)
        {
            // convert steam ids to a csv for the api
            var steamIdsCsv = string.Join(",", steamIds.Select(x => x.ToString()).ToArray());
            var parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamIdsCsv, "steamids");

            var steamWebResponse = await steamWebInterface.GetAsync<PlayerSummaryResultContainer>("GetPlayerSummaries", 2, parameters);

            if (steamWebResponse == null
                || steamWebResponse.Data == null
                || steamWebResponse.Data.Result == null
                || steamWebResponse.Data.Result.Players == null
                || steamWebResponse.Data.Result.Players.Count == 0)
            {
                return null;
            }

            return steamWebResponse.MapTo<IReadOnlyCollection<PlayerSummaryModel>>((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return result.Players?.Select(p => new PlayerSummaryModel
                {
                    SteamId = p.SteamId,
                    ProfileVisibility = p.ProfileVisibility,
                    ProfileState = p.ProfileState,
                    Nickname = p.Nickname,
                    LastLoggedOffDate = p.LastLoggedOffDate,
                    CommentPermission = p.CommentPermission,
                    ProfileUrl = p.ProfileUrl,
                    AvatarUrl = p.AvatarUrl,
                    AvatarMediumUrl = p.AvatarMediumUrl,
                    AvatarFullUrl = p.AvatarFullUrl,
                    UserStatus = p.UserStatus,
                    RealName = p.RealName,
                    PrimaryGroupId = p.PrimaryGroupId,
                    AccountCreatedDate = p.AccountCreatedDate,
                    CountryCode = p.CountryCode,
                    StateCode = p.StateCode,
                    CityCode = p.CityCode,
                    PlayingGameName = p.PlayingGameName,
                    PlayingGameId = p.PlayingGameId,
                    PlayingGameServerIP = p.PlayingGameServerIP
                }).ToList().AsReadOnly();
            });
        }

        /// <summary>
        /// Returns a collection of a specific Steam User's friends list.
        /// </summary>
        /// <param name="steamId"></param>
        /// <param name="relationship"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<FriendModel>>> GetFriendsListAsync(ulong steamId, string relationship = "")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamid");
            parameters.AddIfHasValue(relationship, "relationship");

            var steamWebResponse = await steamWebInterface.GetAsync<FriendsListResultContainer>("GetFriendList", 1, parameters);

            return steamWebResponse.MapTo<IReadOnlyCollection<FriendModel>>((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return result.Friends?.Select(p => new FriendModel
                {
                    SteamId = p.SteamId,
                    FriendSince = p.FriendSince,
                    Relationship = p.Relationship
                }).ToList().AsReadOnly();
            });
        }

        /// <summary>
        /// Returns a collection of a specific Steam User's VAC bans.
        /// </summary>
        /// <param name="steamId"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<PlayerBansModel>>> GetPlayerBansAsync(ulong steamId)
        {
            var result = await GetPlayerBansAsync(new List<ulong>() { steamId });
            return result;
        }

        /// <summary>
        /// Returns a collection of a collection of Steam User's VAC bans.
        /// </summary>
        /// <param name="steamIds"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<PlayerBansModel>>> GetPlayerBansAsync(IReadOnlyCollection<ulong> steamIds)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            string steamIdsParamValue = string.Join(",", steamIds);

            parameters.AddIfHasValue(steamIdsParamValue, "steamids");

            var steamWebResponse = await steamWebInterface.GetAsync<PlayerBansContainer>("GetPlayerBans", 1, parameters);

            return steamWebResponse.MapTo<IReadOnlyCollection<PlayerBansModel>>((from) =>
            {
                var result = from?.PlayerBans;
                if (result == null)
                {
                    return null;
                }

                return result?.Select(p => new PlayerBansModel
                {
                    CommunityBanned = p.CommunityBanned,
                    DaysSinceLastBan = p.DaysSinceLastBan,
                    EconomyBan = p.EconomyBan,
                    NumberOfVACBans = p.NumberOfVACBans,
                    SteamId = p.SteamId,
                    NumberOfGameBans = p.NumberOfGameBans,
                    VACBanned = p.VACBanned
                }).ToList().AsReadOnly();
            });
        }

        /// <summary>
        /// Returns a collection of a specific Steam User's community groups.
        /// </summary>
        /// <param name="steamId"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<ulong>>> GetUserGroupsAsync(ulong steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(steamId, "steamid");

            var steamWebResponse = await steamWebInterface.GetAsync<UserGroupListResultContainer>("GetUserGroupList", 1, parameters);

            return steamWebResponse.MapTo<IReadOnlyCollection<ulong>>((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return result?.Groups?
                    .Select(p => p.Gid)
                    .ToList()
                    .AsReadOnly();
            });
        }

        /// <summary>
        /// Returns the 64-bit Steam ID of a Steam User based on their "Vanity URL" (which is their custom community profile name).
        /// </summary>
        /// <param name="vanityUrl"></param>
        /// <param name="urlType"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<ulong>> ResolveVanityUrlAsync(string vanityUrl, int? urlType = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(vanityUrl, "vanityurl");
            parameters.AddIfHasValue(urlType, "url_type");

            var steamWebResponse = await steamWebInterface.GetAsync<ResolveVanityUrlResultContainer>("ResolveVanityURL", 1, parameters);

            if (steamWebResponse.Data.Result.Success == 42)
            {
                throw new VanityUrlNotResolvedException(ErrorMessages.VanityUrlNotResolved);
            }

            return steamWebResponse.MapTo((from) =>
            {
                return from?.Result?.SteamId ?? 0;
            });
        }

        /// <summary>
        /// Returns a community profile data based on parsing the XML of a Steam User's Community Profile.
        /// </summary>
        /// <param name="steamId"></param>
        /// <returns></returns>
        public async Task<SteamCommunityProfileModel> GetCommunityProfileAsync(ulong steamId)
        {
            HttpClient httpClient = new HttpClient();
            string xml = await httpClient.GetStringAsync(string.Format("http://steamcommunity.com/profiles/{0}?xml=1", steamId));

            var profile = DeserializeXML<SteamCommunityProfile>(xml);

            return new SteamCommunityProfileModel
            {
                AvatarFull = new Uri(profile.AvatarFull),
                Avatar = new Uri(profile.AvatarIcon),
                AvatarMedium = new Uri(profile.AvatarMedium),
                CustomURL = profile.CustomURL,
                MostPlayedGames = profile.MostPlayedGames?.Select(mpg => new SteamCommunityProfileMostPlayedGameModel
                {
                    HoursOnRecord = !string.IsNullOrEmpty(mpg.HoursOnRecord) ? double.Parse(mpg.HoursOnRecord) : 0d,
                    HoursPlayed = !string.IsNullOrEmpty(mpg.HoursPlayed) ? double.Parse(mpg.HoursPlayed) : 0d,
                    Icon = new Uri(mpg.GameIcon),
                    Link = new Uri(mpg.GameLink),
                    Logo = new Uri(mpg.GameLogo),
                    LogoSmall = new Uri(mpg.GameLogoSmall),
                    Name = mpg.GameName,
                    StatsName = mpg.StatsName
                }).ToList().AsReadOnly(),
                Headline = profile.Headline,
                HoursPlayedLastTwoWeeks = !string.IsNullOrEmpty(profile.HoursPlayed2Wk) ? double.Parse(profile.HoursPlayed2Wk) : 0d,
                InGameInfo = profile.InGameInfo == null ? null : new InGameInfoModel
                {
                    GameIcon = profile.InGameInfo.GameIcon,
                    GameLink = profile.InGameInfo.GameLink,
                    GameLogo = profile.InGameInfo.GameLogo,
                    GameLogoSmall = profile.InGameInfo.GameLogoSmall,
                    GameName = profile.InGameInfo.GameName
                },
                IsLimitedAccount = profile.IsLimitedAccount == 1 ? true : false,
                Location = profile.Location,
                MemberSince = profile.MemberSince,
                State = profile.OnlineState,
                StateMessage = profile.StateMessage,
                SteamID = profile.SteamID64,
                SteamRating = !string.IsNullOrEmpty(profile.SteamRating) ? double.Parse(profile.SteamRating) : 0d,
                Summary = profile.Summary,
                TradeBanState = profile.TradeBanState,
                IsVacBanned = profile.VacBanned == 1 ? true : false,
                VisibilityState = profile.VisibilityState,
                InGameServerIP = profile.InGameServerIP,
                RealName = profile.RealName
            };
        }

        private static T DeserializeXML<T>(string xml)
        {
            using (Stream stream = new MemoryStream())
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(xml);
                stream.Write(data, 0, data.Length);
                stream.Position = 0;
                DataContractSerializer deserializer = new DataContractSerializer(typeof(T));
                return (T)deserializer.ReadObject(stream);
            }
        }
    }
}