namespace Forge.Dps.Domain.ValueObjects.Ratings
{
    public class CriticalStrike : Rating
    {
        public static CriticalStrike Zero => new CriticalStrike(0);

        public CriticalStrike(double value) : base(value)
        {
        }

    }
}
