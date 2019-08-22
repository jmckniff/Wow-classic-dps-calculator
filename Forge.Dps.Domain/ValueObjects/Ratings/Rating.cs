using Forge.Dps.Domain.Extensions;

namespace Forge.Dps.Domain.ValueObjects.Ratings
{
    /// <summary>
    /// A rating is an evaluation or assessment of something.
    /// </summary>
    public class Rating
    {
        public double Value { get; private set; }

        public Rating(double value)
        {
            Value = value.ToTwoDecimalPlaces();
        }

        public void Add(double value)
        {
            Value += value.ToTwoDecimalPlaces();
        }

        public static T Combine<T>(T a, T b) where T : Rating
        {
            return new Rating(a.Value + b.Value) as T;
        }
    }
}
