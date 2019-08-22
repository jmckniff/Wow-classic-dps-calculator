using System;
using Forge.Dps.Domain.Extensions;

namespace Forge.Dps.Domain.ValueObjects.Ratings
{
    public class GlancingBlow : Rating
    {
        public double DamageReduction { get; }

        public GlancingBlow(double value, double damageReduction) : base(value)
        {
            DamageReduction = damageReduction.ToTwoDecimalPlaces();
        }
    }
}
