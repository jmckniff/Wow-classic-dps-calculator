using System.Collections.Generic;
using Forge.Dps.Domain.ValueObjects.Items;

namespace Forge.Dps.Domain.ValueObjects.Attribution
{
    public class WeaponSkill : Attribute
    {
        public static WeaponSkill Zero => new WeaponSkill(0, null);

        public WeaponSkill(double value, WeaponType weaponType) : base(value)
        {
            WeaponType = weaponType;
        }

        public WeaponType WeaponType { get; private set; }

        public static WeaponSkills GetWeaponSkills(Level level)
        {
            var weaponSkill = level.Value * 5;

            var weaponSkills = new List<WeaponSkill>
            {
                new WeaponSkill(weaponSkill, new WeaponType(WeaponCategory.Axe, Handedness.OneHanded)),
                new WeaponSkill(weaponSkill, new WeaponType(WeaponCategory.Axe, Handedness.TwoHanded)),
                new WeaponSkill(weaponSkill, new WeaponType(WeaponCategory.Mace, Handedness.OneHanded)),
                new WeaponSkill(weaponSkill, new WeaponType(WeaponCategory.Mace, Handedness.TwoHanded)),
                new WeaponSkill(weaponSkill, new WeaponType(WeaponCategory.Sword, Handedness.OneHanded)),
                new WeaponSkill(weaponSkill, new WeaponType(WeaponCategory.Sword, Handedness.TwoHanded)),
                new WeaponSkill(weaponSkill, new WeaponType(WeaponCategory.Polearm, Handedness.NotApplicable)),
                new WeaponSkill(weaponSkill, new WeaponType(WeaponCategory.Wand, Handedness.NotApplicable)),
                new WeaponSkill(weaponSkill, new WeaponType(WeaponCategory.Staff, Handedness.NotApplicable)),
                new WeaponSkill(weaponSkill, new WeaponType(WeaponCategory.Gun, Handedness.NotApplicable)),
                new WeaponSkill(weaponSkill, new WeaponType(WeaponCategory.Bow, Handedness.NotApplicable)),
                new WeaponSkill(weaponSkill, new WeaponType(WeaponCategory.Crossbow, Handedness.NotApplicable))
            };

            return new WeaponSkills(weaponSkills);
        }
    }
}
