namespace Forge.Dps.Domain.ValueObjects.Attribution
{
    public class Agility : Attribute
    {
        public static Agility Zero => new Agility(0);

        public Agility(double value) : base(value)
        {
        }
    }
}
