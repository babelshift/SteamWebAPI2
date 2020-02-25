namespace Steam.Models.DOTA2
{
    public sealed class DotaSpellImmunityType : DotaEnumType
    {
        public static readonly DotaSpellImmunityType UNKNOWN = new DotaSpellImmunityType("SPELL_IMMUNITY_UNKNOWN", "Unknown", "Spell immunity is unknown on this ability.");
        public static readonly DotaSpellImmunityType ALLIES_YES = new DotaSpellImmunityType("SPELL_IMMUNITY_ALLIES_YES", "Allies", "This ability pierces spell immunity on allies.");
        public static readonly DotaSpellImmunityType ALLIES_NO = new DotaSpellImmunityType("SPELL_IMMUNITY_ALLIES_NO", "Not Allies", "This ability does not pierce spell immunity on allies.");
        public static readonly DotaSpellImmunityType ENEMIES_YES = new DotaSpellImmunityType("SPELL_IMMUNITY_ENEMIES_YES", "Enemies", "This ability pierces spell immunity on enemies.");
        public static readonly DotaSpellImmunityType ENEMIES_NO = new DotaSpellImmunityType("SPELL_IMMUNITY_ENEMIES_NO", "Not Enemies", "This ability does not pierce spell immunity on enemies.");

        public DotaSpellImmunityType(string key, string displayName, string description)
            : base(key, displayName, description)
        { }
    }
}