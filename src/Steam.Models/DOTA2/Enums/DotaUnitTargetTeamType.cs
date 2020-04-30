namespace Steam.Models.DOTA2
{
    public sealed class DotaUnitTargetTeamType : DotaEnumType
    {
        public static readonly DotaUnitTargetTeamType UNKNOWN = new DotaUnitTargetTeamType("DOTA_UNIT_TARGET_TEAM_UNKNOWN", "Unknown", "This unit target type is unknown.");
        public static readonly DotaUnitTargetTeamType ENEMY = new DotaUnitTargetTeamType("DOTA_UNIT_TARGET_TEAM_ENEMY", "Enemies", "The target of the ability must be an enemy.");
        public static readonly DotaUnitTargetTeamType FRIENDLY = new DotaUnitTargetTeamType("DOTA_UNIT_TARGET_TEAM_FRIENDLY", "Friendlies", "The target of the ability must be a friendly.");
        public static readonly DotaUnitTargetTeamType CUSTOM = new DotaUnitTargetTeamType("DOTA_UNIT_TARGET_TEAM_CUSTOM", "Custom", "The target of the ability is a custom type.");
        public static readonly DotaUnitTargetTeamType BOTH = new DotaUnitTargetTeamType("DOTA_UNIT_TARGET_TEAM_BOTH", "Both", "The target of the ability can be both teams.");

        public DotaUnitTargetTeamType(string key, string displayName, string description)
            : base(key, displayName, description)
        { }
    }
}