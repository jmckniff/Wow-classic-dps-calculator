using Forge.Dps.Domain.ValueObjects.Ratings;

namespace Forge.Dps.Domain.ValueObjects.Tables
{
    public class EmptyAttackTableRange : AttackTableRange
    {
        public EmptyAttackTableRange(Rating result) : base(0, 0, result)
        {
        }
    }
}