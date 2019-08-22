using Forge.Dps.Domain.ValueObjects;
using Forge.Dps.Domain.ValueObjects.Attribution;
using Forge.Dps.Domain.ValueObjects.Ratings;
using Forge.Dps.Domain.ValueObjects.Resources;

namespace Forge.Dps.Domain.Interfaces
{
    public interface ICanBeTargeted
    {
        string Name { get; }
        Health Health { get; }
        Level Level { get; }
        Defense Defense { get; }
        Dodge Dodge { get; }
        Parry Parry { get; }
        ArmorAmount Armor { get; }

        CriticalStrike CalculateCriticalStrikeChance(ICanAttack attacker);
    }
}