using SteamWebAPI2.Exceptions;
using SteamWebAPI2.Interfaces;
using System;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models
{
    public enum SteamIdResolvedFrom
    {
        IndividualComponents = 0,
        SteamCommunityUri,
        SteamCommunityProfileName,
        SteamId64,
        AccountIdApproximation
    }

    public enum SteamUniverse
    {
        Invalid = 0,
        Public,
        Beta,
        Internal,
        Dev
    }

    public enum SteamAccountType
    {
        Invalid = 0,
        Individual,
        Multiseat,
        GameServer,
        AnonGameServer,
        Pending,
        ContentServer,
        Clan,
        Chat,
        Chat_Clan,
        Chat_Lobby,
        P2P_SuperSeeder,
        AnonUser
    }

    /// <summary>
    /// A SteamID is a unique identifier used to identify a Steam account. It is also used to refer to a user's Steam Community profile page.
    /// See: https://developer.valvesoftware.com/wiki/SteamID.
    /// </summary>
    public class SteamId
    {
        #region Members

        private uint? instanceId;

        #endregion Members

        #region Properties

        /// <summary>
        /// Identifies which Steam system this Steam Id belongs to. Most Steam Ids are Public (1).
        /// </summary>
        public SteamUniverse Universe { get; private set; }

        /// <summary>
        /// Identifies the account type of the Steam Id. Most Steam Ids are Individual (1).
        /// </summary>
        public SteamAccountType AccountType { get; private set; }

        /// <summary>
        /// Not really sure. It seems to mostly be "1".
        /// </summary>
        public uint? InstanceId
        {
            get
            {
                if (instanceId.HasValue) { return instanceId.Value; }
                else { return 0; }
            }
            set
            {
                instanceId = value;
            }
        }

        /// <summary>
        /// A user's unique account id (sometimes incorrectly referred to as "SteamId32" or "32-bit Steam Id". This is the lowest 32-bits of the 64-bit Steam Id.
        /// </summary>
        public uint AccountId { get; private set; }

        public SteamIdResolvedFrom ResolvedFrom { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Constructs a Steam Id from the four components.
        /// </summary>
        /// <param name="universe">Which Steam system this Steam Id belongs to (such as Public)</param>
        /// <param name="accountType">The type of account for this Steam Id (such as Individual)</param>
        /// <param name="accountId">The 32-bit account identifier for the Steam account</param>
        /// <param name="instanceId">Not really sure. It seems to mostly be "1".</param>
        public SteamId(SteamUniverse universe, SteamAccountType accountType, uint accountId, uint instanceId)
        {
            Universe = universe;
            AccountType = accountType;
            InstanceId = instanceId;
            AccountId = accountId;

            ResolvedFrom = SteamIdResolvedFrom.IndividualComponents;
        }

        /// <summary>
        /// Constructs a Steam Id from three of the four components. Instance is defaulted to a value based on the Account Type.
        /// </summary>
        /// <param name="universe">Which Steam system this Steam Id belongs to (such as Public)</param>
        /// <param name="accountType">The type of account for this Steam Id (such as Individual)</param>
        /// <param name="accountId">The 32-bit account identifier for the Steam account</param>
        public SteamId(SteamUniverse universe, SteamAccountType accountType, uint accountId)
        {
            Universe = universe;
            AccountType = accountType;
            AccountId = accountId;

            if (AccountType == SteamAccountType.Individual)
            {
                InstanceId = 1;
            }

            ResolvedFrom = SteamIdResolvedFrom.IndividualComponents;
        }

        /// <summary>
        /// Constructs an approximated Steam Id based on a 32-bit Account Id. Since a full Steam Id includes more than just an Account Id, it is
        /// impossible to convert directly from Account Id to 64-bit Steam Id without making some assumptions. This constructor will assume the following.
        /// Universe: Public (1), Instance: 1, AccountType: Individual (1).
        /// </summary>
        /// <param name="accountId">32-bit Account Id portion of the Steam Id (the lowest 32-bits of the 64-bit Steam Id)</param>
        public SteamId(uint accountId)
        {
            AccountId = accountId;

            ulong steamId64 = (ulong)AccountId | 0x110000100000000;

            ConstructFromSteamId64(steamId64);

            ResolvedFrom = SteamIdResolvedFrom.AccountIdApproximation;
        }

        /// <summary>
        /// Constructs a Steam Id based on its 64-bit representation. The Universe, Account Type, Instance, and Account Id will be extracted from the 64-bit value.
        /// </summary>
        /// <param name="steamId64">The 64-bit Steam Id</param>
        public SteamId(ulong steamId64)
        {
            ConstructFromSteamId64(steamId64);
            ResolvedFrom = SteamIdResolvedFrom.SteamId64;
        }

        /// <summary>
        /// Constructs a Steam Id by parsing the provided value. This constructor will try to parse the value to a 64-bit Steam Id or a Steam Community Profile URL depending on the input.
        /// If a Profile URL is provided but is unable to be resolved to a 64-bit Steam ID, a VanityUrlNotResolvedException will be thrown.
        /// </summary>
        /// <param name="value">Value to parse, can be a 64-bit Steam ID, a full Steam Community Profile URL, or the user's Steam Community Profile Name.</param>
        /// <param name="steamWebApiKey">Required in the event that the Steam Web API is required to resolve a Profiel URL to a 64-bit Steam ID.</param>
        public SteamId(string value, string steamWebApiKey)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value");
            }

            if (String.IsNullOrEmpty(steamWebApiKey))
            {
                throw new ArgumentNullException("steamWebApiKey");
            }

            ulong steamId = 0;

            // first check to see if the caller provided a 64-bit Steam ID
            bool isSteamId64 = ulong.TryParse(value, out steamId);

            // the caller didn't provide a 64-bit Steam ID
            if (!isSteamId64)
            {
                // check if the caller entered a valid uri
                Uri uriResult;
                bool isUri = Uri.TryCreate(value, UriKind.Absolute, out uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                SteamUser steamUser = new SteamUser(steamWebApiKey);

                try
                {
                    Task.Run(async () =>
                    {
                        // the caller provided a uri
                        if (isUri)
                        {
                            // the caller provided a uri in the format we expected
                            if (uriResult.Segments.Length == 3)
                            {
                                string profileId = uriResult.Segments[2];

                                // try to parse the 3rd segment as a 64-bit Steam ID (http://steamcommunity.com/profiles/762541427451 for example)
                                isSteamId64 = ulong.TryParse(profileId, out steamId);

                                // the third segment isn't a 64-bit Steam ID, check if it's a profile name which resolves to a 64-bit Steam ID
                                if (!isSteamId64)
                                {
                                    steamId = await ResolveSteamIdFromValueAsync(steamUser, profileId);
                                }
                            }
                            else
                            {
                                throw new InvalidSteamCommunityUriException(ErrorMessages.InvalidSteamCommunityUri);
                            }

                            ResolvedFrom = SteamIdResolvedFrom.SteamCommunityUri;
                        }
                        else
                        {
                            // not a 64-bit Steam ID and not a uri, try to just resolve it as if it was a Steam Community Profile Name
                            steamId = await ResolveSteamIdFromValueAsync(steamUser, value);
                            ResolvedFrom = SteamIdResolvedFrom.SteamCommunityProfileName;
                        }
                    }).Wait();
                }
                catch (AggregateException ex)
                {
                    foreach (var innerEx in ex.InnerExceptions)
                    {
                        // throw the first specific exception that we expect
                        if (innerEx is VanityUrlNotResolvedException || innerEx is InvalidSteamCommunityUriException)
                        {
                            ExceptionDispatchInfo.Capture(innerEx).Throw();
                        }
                    }

                    // otherwise just throw the Aggregate and let the caller handle it
                    throw;
                }
            }
            else
            {
                ResolvedFrom = SteamIdResolvedFrom.SteamId64;
            }

            if (steamId > 0)
            {
                ConstructFromSteamId64(steamId);
            }
            else
            {
                throw new SteamIdNotConstructedException(ErrorMessages.SteamIdNotConstructed);
            }
        }

        /// <summary>
        /// Queries the Steam Web API for a 64-bit Steam ID based on a provided string value.
        /// </summary>
        /// <param name="steamUser"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static async Task<ulong> ResolveSteamIdFromValueAsync(SteamUser steamUser, string value)
        {
            ulong steamId64 = 0;

            var result = await steamUser.ResolveVanityUrlAsync(value);

            // the value didn't resolve to a 64-bit Steam ID
            if (result.Success == 42) // returns 42 on "no match"
            {
                throw new VanityUrlNotResolvedException(ErrorMessages.VanityUrlNotResolved);
            }
            else
            {
                steamId64 = result.SteamId;
            }

            return steamId64;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Returns a Steam Id in the following format: STEAM_X:Y:Z where X is Universe, Y is lowest bit of Account Id, and Z is the highest 31-bits of Account Id.
        /// </summary>
        /// <returns>A Steam Id string such as STEAM_X:Y:Z</returns>
        public string ToLegacyFormat()
        {
            // X = universe
            int x = (int)Universe;

            // Z = highest 31 bits of Account Id
            uint z = (AccountId >> 1) & 0x7FFFFFFF;

            // Y = lowest bit of Account Id (always 0 or 1)
            uint y = AccountId & 1;

            return String.Format("STEAM_{0}:{1}:{2}", x, y, z);
        }

        /// <summary>
        /// Returns a Steam Id in the following format: [C:U:A] or [C:U:A:I] where C is Account Type character identifier, U is Universe, A is Account Id, and I is Instance Id.
        /// If there is no Instance Id, the value is omitted from the resulting string.
        /// </summary>
        /// <returns>A Steam Id string such as [C:U:A] or [C:U:A:I]</returns>
        public string ToModernFormat()
        {
            // C = a char representing the account type or a combination of account type + instance id
            char c = GetAccountTypeCharacter(AccountType);

            // U = universe
            int u = (int)Universe;

            // A = account id
            uint a = AccountId;

            return String.Format("[{0}:{1}:{2}]", c, u, a);
        }

        /// <summary>
        /// Returns the 64-bit representation of the Steam Id by combining the Universe, Account Id, Account Type, and Instance Id.
        /// </summary>
        /// <returns></returns>
        public ulong To64Bit()
        {
            // low 32 bits = account id
            ulong low32bits = AccountId;

            // next 20 bits = instance
            ulong next20bits = (ulong)InstanceId << 32;

            // next 4 bits = account type
            ulong next4bits = (ulong)AccountType << 52;

            // next 8 bits = universe
            ulong next8bits = (ulong)Universe << 56;

            return next8bits | next4bits | next20bits | low32bits;
        }

        /// <summary>
        /// Decompiles the 64-bit Steam Id into its 4 components based on bit manipulation
        /// </summary>
        /// <param name="steamId64">64-bit representation of the Steam Id</param>
        private void ConstructFromSteamId64(ulong steamId64)
        {
            // Account Id = low 32 bits
            AccountId = (uint)steamId64;

            // Instance Id = next 20 bits
            InstanceId = (uint)(steamId64 >> 32) & 0xFFFFF;

            // Account Type = 4 bits
            AccountType = (SteamAccountType)((uint)(steamId64 >> 52) & 0xF);

            // Universe = 8 bits
            Universe = (SteamUniverse)((uint)(steamId64 >> 56) & 0xFF);
        }

        /// <summary>
        /// Returns the account type identifier character based on the account type.
        /// </summary>
        /// <param name="accountType">A character identifier for the account type</param>
        /// <returns></returns>
        private char GetAccountTypeCharacter(SteamAccountType accountType)
        {
            switch (accountType)
            {
                case SteamAccountType.Invalid:
                    return 'I';

                case SteamAccountType.Individual:
                    return 'U';

                case SteamAccountType.Multiseat:
                    return 'M';

                case SteamAccountType.GameServer:
                    return 'G';

                case SteamAccountType.AnonGameServer:
                    return 'A';

                case SteamAccountType.Pending:
                    return 'P';

                case SteamAccountType.ContentServer:
                    return 'C';

                case SteamAccountType.Clan:
                    return 'g';

                case SteamAccountType.Chat:
                    return 'T';

                case SteamAccountType.Chat_Clan:
                    return 'c';

                case SteamAccountType.Chat_Lobby:
                    return 'L';

                case SteamAccountType.AnonUser:
                    return 'a';

                default:
                    return ' ';
            }
        }

        #endregion Methods
    }
}