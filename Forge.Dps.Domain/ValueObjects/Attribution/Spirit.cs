namespace Forge.Dps.Domain.ValueObjects.Attribution
{
    public class Spirit : Attribute
    {
        public static Spirit Zero => new Spirit(0);

        public Spirit(double value) : base(value)
        {
        }
    }
}
