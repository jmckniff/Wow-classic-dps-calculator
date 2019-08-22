namespace Forge.Dps.Domain.ValueObjects.Attribution
{
    public class Strength : Attribute
    {
        public static Strength Zero => new Strength(0);

        public Strength(double value) : base(value)
        {
        }
    }
}
