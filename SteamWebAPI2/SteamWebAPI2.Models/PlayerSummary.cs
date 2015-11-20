using Newtonsoft.Json;
using SteamWebAPI2.Models.Utilities;
using System;

namespace SteamWebAPI2.Models
{
    public enum UserStatus
    {
        Offline = 0,
        Online = 1,
        Busy = 2,
        Away = 3,
        Snooze = 4,
        Unknown = 5,
        InGame = 6
    }

    public enum ProfileVisibility
    {
        Unknown = 0,
        Private = 1,
        Public = 3,
        FriendsOnly = 8,
    }

    public enum CommentPermission
    {
        Unknown = 0,
        FriendsOnly = 1,
        Private = 2,
        Public = 3
    }

    public class PlayerSummary
    {
        /// <summary>
        /// Unique Steam ID of the player. Resolve this using ResolveVanityUrl interface method.
        /// </summary>
        [JsonProperty(PropertyName = "steamid")]
        public string SteamId { get; set; }

        /// <summary>
        /// Determines the visibility of the user's profile (public, private, friends)
        /// </summary>
        [JsonProperty(PropertyName = "communityvisibilitystate")]
        public ProfileVisibility ProfileVisibility { get; set; }

        /// <summary>
        /// If set to 1, the user has configured his profile.
        /// </summary>
        [JsonProperty(PropertyName = "profilestate")]
        public int ProfileState { get; set; }

        /// <summary>
        /// User's current nick name (displayed in profile and friends list)
        /// </summary>
        [JsonProperty(PropertyName = "personaname")]
        public string Nickname { get; set; }

        [JsonProperty(PropertyName = "lastlogoff")]
        [JsonConverter(typeof(UnixTimeJsonConverter))]
        public DateTime LastLoggedOffDate { get; set; }

        [JsonProperty(PropertyName = "commentpermission")]
        public CommentPermission CommentPermission { get; set; }

        [JsonProperty(PropertyName = "profileurl")]
        public string ProfileUrl { get; set; }

        [JsonProperty(PropertyName = "avatar")]
        public string AvatarUrl { get; set; }

        [JsonProperty(PropertyName = "avatarmedium")]
        public string AvatarMediumUrl { get; set; }

        [JsonProperty(PropertyName = "avatarfull")]
        public string AvatarFullUrl { get; set; }

        [JsonProperty(PropertyName = "personastate")]
        public UserStatus UserStatus { get; set; }

        [JsonProperty(PropertyName = "realname")]
        public string RealName { get; set; }

        [JsonProperty(PropertyName = "primaryclanid")]
        public string PrimaryGroupId { get; set; }

        [JsonProperty(PropertyName = "timecreated")]
        [JsonConverter(typeof(UnixTimeJsonConverter))]
        public DateTime AccountCreatedDate { get; set; }

        [JsonProperty(PropertyName = "loccountrycode")]
        public string CountryCode { get; set; }

        [JsonProperty(PropertyName = "locstatecode")]
        public string StateCode { get; set; }

        [JsonProperty(PropertyName = "loccityid")]
        public int CityCode { get; set; }

        [JsonProperty(PropertyName = "gameextrainfo")]
        public string PlayingGameName { get; set; }

        [JsonProperty(PropertyName = "gameid")]
        public string PlayingGameId { get; set; }
    }
}