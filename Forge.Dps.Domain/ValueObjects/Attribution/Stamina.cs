namespace Forge.Dps.Domain.ValueObjects.Attribution
{
    public class Stamina : Attribute
    {
        public static Stamina Zero => new Stamina(0);
        public Stamina(double value) : base(value)
        {
        }
    }
}
