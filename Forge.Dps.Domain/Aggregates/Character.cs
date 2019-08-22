using Forge.Dps.Domain.Entities;
using Forge.Dps.Domain.Interfaces;
using Forge.Dps.Domain.ValueObjects;
using Forge.Dps.Domain.ValueObjects.Attribution;
using Forge.Dps.Domain.ValueObjects.Classes;
using Forge.Dps.Domain.ValueObjects.Ratings;

namespace Forge.Dps.Domain.Aggregates
{
    public class Character : ICanAttack
    {
        public PrimaryAttributes PrimaryAttributes { get; }
        public SecondaryAttributes SecondaryAttributes { get; }
        public Class Class { get; }
        public Equipment Equipment { get; }

        #region Calculated Properties
        public Level Level => Class.Level;
        public WeaponSkill MainHandWeaponSkill => SecondaryAttributes.WeaponSkills.Get(MainHandWeapon.Type);
        public WeaponSkill OffHandWeaponSkill => SecondaryAttributes.WeaponSkills.Get(OffHandWeapon.Type);
        public Weapon MainHandWeapon => Equipment.MainHandWeapon;
        public Weapon OffHandWeapon => Equipment.OffHandWeapon;
        public CriticalStrike CriticalStrike => SecondaryAttributes.CriticalStrike;
        public bool IsDualWielding => MainHandWeapon != null && OffHandWeapon != null;
        #endregion Calculate Properties

        public Character(Class @class, Equipment equipment)
        {
            Class = @class;
            Equipment = equipment;

            PrimaryAttributes = Class.PrimaryAttributes.Combine(Equipment.PrimaryAttributes);

            var equipmentSecondaryAttributesFromPrimary = Class.CalculateSecondaryAttributes(Equipment.PrimaryAttributes);
            var totalEquipmentSecondaryAttributes = Equipment.SecondaryAttributes.Combine(equipmentSecondaryAttributesFromPrimary);

            SecondaryAttributes = Class.SecondaryAttributes.Combine(totalEquipmentSecondaryAttributes);
        }

        public double MainHandAverageDamagePerSwing()
        {
            //var attributes = Class.CalculateAttributes();
            //// (Weapon DPS + AP DPS) * Weapon Speed.
            //return (Equipment.MainHandWeapon.CalculateDps().Value + 
            //        attributes.MeleeAttackPower.CalculateDps().Value) *
            //        Equipment.MainHandWeapon.Speed;

            return 0;
        }
    }
}
