using System.Collections.Generic;
using Forge.Dps.Domain.Entities;
using Forge.Dps.Domain.ValueObjects;
using Forge.Dps.Domain.ValueObjects.Attribution;
using Forge.Dps.Domain.ValueObjects.Items;
using Forge.Dps.Domain.ValueObjects.Ratings;
using Forge.Dps.Domain.ValueObjects.Resources;
using Forge.ItemData.File.Models;

namespace Forge.ItemData.File.Mappers
{
    public class WeaponMapper
    {
        public Weapon MapFrom(ItemModel model, Handedness handedness)
        {
            var item = new Weapon(
                model.Name,
                new ItemIdentifier(model.Name),
                new PrimaryAttributes(
                    new Strength((double)model.Strength),
                    new Agility((double)model.Agility),
                    new Stamina((double)model.Stamina),
                    Intellect.Zero,
                    Spirit.Zero), 
                new SecondaryAttributes(
                    Health.Zero, 
                    new CriticalStrike((double)model.Crit),
                    new Hit((double)model.Hit),
                    new Dodge((double)model.Dodge),
                    new Parry((double)model.Parry),
                    new Defense((double)model.Defense),
                    BlockDamage.Zero,
                    new MeleeAttackPower((double)model.AP),
                    new RangedAttackPower((double)model.AP),
                    new ArmorAmount((double)model.AC),
                    new WeaponSkills()),
                new WeaponType(GetWeaponCategory(model.WeaponType), handedness),
                new DamageRange(model.MinimumHit, model.MaximumHit),
                model.Speed,
                WeaponProc.None
                );

            return item;
        }

        private WeaponCategory GetWeaponCategory(int weaponType)
        {
            var weaponTypes = new Dictionary<int, WeaponCategory>
            {
                {1, WeaponCategory.Axe},
                {2, WeaponCategory.Dagger},
                {3, WeaponCategory.Fist},
                {4, WeaponCategory.Mace},
                {5, WeaponCategory.Sword},
                {6, WeaponCategory.Polearm},
                {7, WeaponCategory.Bow},
                {8, WeaponCategory.Crossbow},
                {9, WeaponCategory.Gun},
            };

            return weaponTypes[weaponType];
        }
    }
}
