namespace Forge.Dps.Domain.ValueObjects.Attribution
{
    public class BlockDamage : Attribute
    {
        public static BlockDamage Zero = new BlockDamage(0);

        public BlockDamage(double value) : base(value)
        {
        }
    }
}
