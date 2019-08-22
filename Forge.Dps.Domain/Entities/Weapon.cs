using System;
using Forge.Dps.Domain.ValueObjects;
using Forge.Dps.Domain.ValueObjects.Attribution;
using Forge.Dps.Domain.ValueObjects.Items;

namespace Forge.Dps.Domain.Entities
{
    public class Weapon : Item
    {
        public WeaponType Type { get; private set; }
        public DamageRange DamageRange { get; private set; }
        public double Speed { get; private set; }
        public WeaponProc Proc { get; private set; }

        public Weapon(
            string name,
            ItemIdentifier identifier,
            PrimaryAttributes primaryAttributes,
            SecondaryAttributes secondaryAttributes, 
            WeaponType type,
            DamageRange damageRange, 
            double speed,
            WeaponProc proc) 
            : base(
                name,
                identifier, 
                primaryAttributes, 
                secondaryAttributes)
        {
            Type = type;
            DamageRange = damageRange;
            Speed = speed;
            Proc = proc;
        }

        /// <summary>
        /// Calculate weapon white dps, this does not include any weapon proc.
        /// </summary>
        public DamagePerSecond CalculateDps()
        {
            // ((Min Weapon Damage + Max Weapon Damage) / 2) / Weapon Speed
            var weaponDps = ((DamageRange.Min + DamageRange.Max) / 2.00f) / Speed;

            var weaponDpsRounded = (double)Math.Round(weaponDps, 2);

            return new DamagePerSecond(weaponDpsRounded);
        }
    }
}
