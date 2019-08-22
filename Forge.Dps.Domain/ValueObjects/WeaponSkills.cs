using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Forge.Dps.Domain.ValueObjects.Attribution;
using Forge.Dps.Domain.ValueObjects.Items;

namespace Forge.Dps.Domain.ValueObjects
{
    public class WeaponSkills : IEnumerable<WeaponSkill>
    {
        private readonly List<WeaponSkill> _weaponSkills;

        public WeaponSkills()
        {
            _weaponSkills = new List<WeaponSkill>();
        }

        public WeaponSkills(List<WeaponSkill> weaponSkills)
        {
            _weaponSkills = weaponSkills;
        }

        public WeaponSkill Get(WeaponType weaponType)
        {
            return _weaponSkills
                .FirstOrDefault(skill =>
                    skill.WeaponType.Category == weaponType.Category &&
                    skill.WeaponType.Handedness == weaponType.Handedness);
        }

        public void Add(WeaponSkill weaponSkill)
        {
            var existingWeaponSkill = _weaponSkills.FirstOrDefault(x => x.WeaponType == weaponSkill.WeaponType);

            if (existingWeaponSkill != null)
            {
                existingWeaponSkill.Add(weaponSkill.Value);
            }
            else
            {
                _weaponSkills.Add(weaponSkill);
            }
        }

        public void Add(WeaponSkills weaponSkills)
        {
            foreach (var weaponSkill in weaponSkills)
            {
                Add(weaponSkill);
            }
        }

        public static WeaponSkills Combine(WeaponSkills a, WeaponSkills b)
        {
            var combineWeaponSkills = new WeaponSkills();

            foreach (var weaponSkill in a)
            {
                combineWeaponSkills.Add(weaponSkill);
            }

            foreach (var weaponSkill in b)
            {
                combineWeaponSkills.Add(weaponSkill);
            }

            return combineWeaponSkills;
        }

        public IEnumerator<WeaponSkill> GetEnumerator()
        {
            return _weaponSkills.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
