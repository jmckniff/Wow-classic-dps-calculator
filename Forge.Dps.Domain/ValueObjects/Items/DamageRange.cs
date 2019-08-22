namespace Forge.Dps.Domain.ValueObjects.Items
{
    public class DamageRange
    {
        public DamageRange(double min, double max)
        {
            Min = min;
            Max = max;
        }

        public double Min { get; private set; }
        public double Max { get; private set; }
    }
}
