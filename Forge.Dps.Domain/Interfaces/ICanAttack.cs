using Forge.Dps.Domain.Entities;
using Forge.Dps.Domain.ValueObjects;
using Forge.Dps.Domain.ValueObjects.Attribution;
using Forge.Dps.Domain.ValueObjects.Ratings;

namespace Forge.Dps.Domain.Interfaces
{
    public interface ICanAttack
    {
        Level Level { get; }
        WeaponSkill MainHandWeaponSkill { get; }
        WeaponSkill OffHandWeaponSkill { get; }
        Weapon MainHandWeapon { get; }
        Weapon OffHandWeapon { get; }
        CriticalStrike CriticalStrike { get; }
    }
}