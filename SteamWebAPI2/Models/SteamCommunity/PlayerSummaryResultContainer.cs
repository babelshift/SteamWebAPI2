using Newtonsoft.Json;
using Steam.Models.SteamCommunity;
using SteamWebAPI2.Utilities.JsonConverters;
using System;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.SteamCommunity
{
    /// <summary>
    /// Represents a single player summary from ISteamUser/GetPlayerSummaries interface/method. Not every field will be populated
    /// depending on the user's privacy choices or omission of data completely.
    /// </summary>
    /// </summary>
    internal class PlayerSummary
    {
        /// <summary>
        /// Unique Steam ID of the player. Resolve this using ResolveVanityUrl interface method.
        /// </summary>
        [JsonProperty(PropertyName = "steamid")]
        public ulong SteamId { get; set; }

        /// <summary>
        /// Determines the visibility of the user's profile (public, private, friends)
        /// </summary>
        [JsonProperty(PropertyName = "communityvisibilitystate")]
        public ProfileVisibility ProfileVisibility { get; set; }

        /// <summary>
        /// If set to 1, the user has configured his profile.
        /// </summary>
        [JsonProperty(PropertyName = "profilestate")]
        public uint ProfileState { get; set; }

        /// <summary>
        /// User's current nick name (displayed in profile and friends list)
        /// </summary>
        [JsonProperty(PropertyName = "personaname")]
        public string Nickname { get; set; }

        /// <summary>
        /// The date at which the user last logged off Steam
        /// It's a 64-bit integer in the JSON response, so we parse it to a DateTime
        /// </summary>
        [JsonProperty(PropertyName = "lastlogoff")]
        [JsonConverter(typeof(UnixTimeJsonConverter))]
        public DateTime LastLoggedOffDate { get; set; }

        /// <summary>
        /// The selected privacy/visibility level of the player's comments section on their Steam Community profile
        /// </summary>
        [JsonProperty(PropertyName = "commentpermission")]
        public CommentPermission CommentPermission { get; set; }

        /// <summary>
        /// The URL for the player's Steam Community profile
        /// </summary>
        [JsonProperty(PropertyName = "profileurl")]
        public string ProfileUrl { get; set; }

        /// <summary>
        /// The normal sized uploaded avatar image for the user's Steam profile
        /// </summary>
        [JsonProperty(PropertyName = "avatar")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// The medium sized uploaded avatar image for the user's Steam profile
        /// </summary>
        [JsonProperty(PropertyName = "avatarmedium")]
        public string AvatarMediumUrl { get; set; }

        /// <summary>
        /// THe full sized uploaded avatar image for the user's Steam profile
        /// </summary>
        [JsonProperty(PropertyName = "avatarfull")]
        public string AvatarFullUrl { get; set; }

        /// <summary>
        /// The current status of the user on the Steam network
        /// </summary>
        [JsonProperty(PropertyName = "personastate")]
        public UserStatus UserStatus { get; set; }

        /// <summary>
        /// The player's real name as entered on their Steam profile
        /// </summary>
        [JsonProperty(PropertyName = "realname")]
        public string RealName { get; set; }

        /// <summary>
        /// The player's selected primary group to display on their Steam profile
        /// </summary>
        [JsonProperty(PropertyName = "primaryclanid")]
        public string PrimaryGroupId { get; set; }

        /// <summary>
        /// The date at which the user created their Steam account
        /// It's a 64-bit integer in the JSON response, so we parse it to a DateTime
        /// </summary>
        [JsonProperty(PropertyName = "timecreated")]
        [JsonConverter(typeof(UnixTimeJsonConverter))]
        public DateTime AccountCreatedDate { get; set; }

        /// <summary>
        /// The player's selected country
        /// </summary>
        [JsonProperty(PropertyName = "loccountrycode")]
        public string CountryCode { get; set; }

        /// <summary>
        /// The player's selected state
        /// </summary>
        [JsonProperty(PropertyName = "locstatecode")]
        public string StateCode { get; set; }

        /// <summary>
        /// The player's selected city. This seems to refer to a database city id, so I'm not sure how to make use of this field.
        /// </summary>
        [JsonProperty(PropertyName = "loccityid")]
        public uint CityCode { get; set; }

        /// <summary>
        /// The name of the game that a player is currently playing
        /// </summary>
        [JsonProperty(PropertyName = "gameextrainfo")]
        public string PlayingGameName { get; set; }

        /// <summary>
        /// The id of the game that the player is currently playing. This doesn't seem to be an appid, so I'm not sure how to make use of this field.
        /// </summary>
        [JsonProperty(PropertyName = "gameid")]
        public string PlayingGameId { get; set; }
    }

    /// <summary>
    /// Represents the list of player summaries from ISteamUser/GetPlayerSummaries interface/method.
    /// </summary>
    internal class PlayerSummaryResult
    {
        /// <summary>
        /// Contains the list of player summaries in the JSON response.
        /// </summary>
        public IList<PlayerSummary> Players { get; set; }
    }

    /// <summary>
    /// Represents the container of the response from ISteamUser/GetPlayerSummaries interface/method.
    /// </summary>
    internal class PlayerSummaryResultContainer
    {
        /// <summary>
        /// The JSON response has a top level "response" object
        /// </summary>
        [JsonProperty(PropertyName = "response")]
        public PlayerSummaryResult Result { get; set; }
    }
}