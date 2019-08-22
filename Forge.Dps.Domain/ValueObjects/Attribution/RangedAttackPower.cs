namespace Forge.Dps.Domain.ValueObjects.Attribution
{
    public class RangedAttackPower : Attribute
    {
        public static RangedAttackPower Zero = new RangedAttackPower(0);

        public RangedAttackPower(double value) : base(value)
        {
            
        }
    }
}
