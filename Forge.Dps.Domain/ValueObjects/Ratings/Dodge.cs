namespace Forge.Dps.Domain.ValueObjects.Ratings
{
    public class Dodge : Rating
    {
        public static Dodge Zero => new Dodge(0);

        public Dodge(double value) : base(value)
        {
        }
    }
}
