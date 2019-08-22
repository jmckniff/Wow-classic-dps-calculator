namespace Forge.Dps.Domain.ValueObjects
{
    public class DamagePerSecond
    {
        public DamagePerSecond(double value)
        {
            Value = value;
        }

        public double Value { get; private set; }
        
    }
}