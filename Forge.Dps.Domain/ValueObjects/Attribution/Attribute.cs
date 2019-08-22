using System;
using Forge.Dps.Domain.Extensions;

namespace Forge.Dps.Domain.ValueObjects.Attribution
{
    /// <summary>
    /// A stat is a quantity.
    /// </summary>
    public class Attribute
    {
        public double Value { get; private set; }

        public Attribute(double value)
        {
            Value = value.ToTwoDecimalPlaces();
        }

        public void Add(double value)
        {
            Value += value.ToTwoDecimalPlaces();
        }

        public static T Combine<T>(T a, T b) where T : Attribute
        {
            return (T)new Attribute(a.Value + b.Value);
        }
    }
}
