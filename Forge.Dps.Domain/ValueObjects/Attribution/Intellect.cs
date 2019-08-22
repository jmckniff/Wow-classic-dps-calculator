namespace Forge.Dps.Domain.ValueObjects.Attribution
{
    public class Intellect : Attribute
    {
        public static Intellect Zero => new Intellect(0);

        public Intellect(double value) : base(value)
        {
        }
    }
}
