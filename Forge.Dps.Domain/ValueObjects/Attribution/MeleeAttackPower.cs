namespace Forge.Dps.Domain.ValueObjects.Attribution
{
    public class MeleeAttackPower : Attribute
    {
        public static MeleeAttackPower Zero = new MeleeAttackPower(0);

        public MeleeAttackPower(double value) : base(value)
        {
        }

        public DamagePerSecond CalculateDps()
        {
            // Attack power increases your base DPS by 1 for every 14 attack power.
            var dps = Value / 14.00f;

            return new DamagePerSecond(dps);
        }
    }
}
