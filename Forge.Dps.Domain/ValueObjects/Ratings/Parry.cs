using Forge.Dps.Domain.Aggregates;
using Forge.Dps.Domain.Interfaces;

namespace Forge.Dps.Domain.ValueObjects.Ratings
{
    public class Parry : Rating
    {
        public static Parry Zero => new Parry(0);

        public Parry(double value) : base(value)
        {
        }
    }
}
