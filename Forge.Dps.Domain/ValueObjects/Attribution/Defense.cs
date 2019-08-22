namespace Forge.Dps.Domain.ValueObjects.Attribution
{
    public class Defense : Attribute
    {
        public static Defense Zero => new Defense(0);

        public Defense(double value) : base(value)
        {
        }
    }
}
