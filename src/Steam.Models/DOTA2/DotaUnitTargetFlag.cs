namespace Steam.Models.DOTA2
{
    public sealed class DotaUnitTargetFlag : DotaEnumType
    {
        public static readonly DotaUnitTargetFlag UNKNOWN = new DotaUnitTargetFlag("DOTA_UNIT_TARGET_FLAG_UNKNOWN", "Unknown", "This flag is an unknown type.");
        public static readonly DotaUnitTargetFlag MAGIC_IMMUNE_ENEMIES = new DotaUnitTargetFlag("DOTA_UNIT_TARGET_FLAG_MAGIC_IMMUNE_ENEMIES", "Affects Magic Immune Enemies", "This ability affects magic immune enemies.");
        public static readonly DotaUnitTargetFlag INVULNERABLE = new DotaUnitTargetFlag("DOTA_UNIT_TARGET_FLAG_INVULNERABLE", "Affects Invulnerable Units", "This ability affects invulernable targets.");
        public static readonly DotaUnitTargetFlag NOT_MAGIC_IMMUNE_ALLIES = new DotaUnitTargetFlag("DOTA_UNIT_TARGET_FLAG_NOT_MAGIC_IMMUNE_ALLIES", "Does Not Affect Magic Immune Allies", "This ability does not affect magic immune allies.");
        public static readonly DotaUnitTargetFlag NOT_ANCIENTS = new DotaUnitTargetFlag("DOTA_UNIT_TARGET_FLAG_NOT_ANCIENTS", "Does Not Affect Ancients", "This ability does not affect ancients.");
        public static readonly DotaUnitTargetFlag NOT_SUMMONED = new DotaUnitTargetFlag("DOTA_UNIT_TARGET_FLAG_NOT_SUMMONED", "Does Not Affect Summoned", "This ability does not affect summoned targets.");
        public static readonly DotaUnitTargetFlag NOT_CREEP_HERO = new DotaUnitTargetFlag("DOTA_UNIT_TARGET_FLAG_NOT_CREEP_HERO", "Does Not Affect Creeps or Heroes", "This ability does not affect creep or hero targets.");

        public DotaUnitTargetFlag(string key, string displayName, string description)
            : base(key, displayName, description)
        { }
    }
}