namespace Steam.Models.DOTA2
{
    public sealed class DotaDamageType : DotaEnumType
    {
        public static readonly DotaDamageType UNKNOWN = new DotaDamageType("DAMAGE_TYPE_UNKNOWN", "Unknown", "This damage type is unknown.");
        public static readonly DotaDamageType PURE = new DotaDamageType("DAMAGE_TYPE_PURE", "Pure", "The damage dealt is not reduced by any resistance.");
        public static readonly DotaDamageType PHYSICAL = new DotaDamageType("DAMAGE_TYPE_PHYSICAL", "Physical", "The damage dealth is reduced by armor.");
        public static readonly DotaDamageType MAGICAL = new DotaDamageType("DAMAGE_TYPE_MAGICAL", "Magical", "The damage dealt is reduced by spell resistance.");

        public DotaDamageType(string key, string displayName, string description)
            : base(key, displayName, description)
        { }
    }
}