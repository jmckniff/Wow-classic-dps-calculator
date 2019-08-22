using Forge.Dps.Domain.ValueObjects.Ratings;

namespace Forge.Dps.Domain.ValueObjects.Tables
{
    public class AttackTableRange
    {
        public double Min { get; }
        public double Max { get; }
        public Rating Result { get; }

        public AttackTableRange(double min, double max, Rating result)
        {
            Min = min;
            Max = max;
            Result = result;
        }

        public override string ToString()
        {
            return $"{Result.GetType().UnderlyingSystemType.Name}: {Result.Value}% ({Min}-{Max})";
        }
    }
}
