namespace Forge.Dps.Domain.ValueObjects.Ratings
{
    public class Hit : Rating
    {
        public static Hit Zero => new Hit(0);
        public Hit(double value) : base(value)
        {
        }
    }
}
