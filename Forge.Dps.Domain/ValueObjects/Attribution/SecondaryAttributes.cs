using Forge.Dps.Domain.ValueObjects.Ratings;
using Forge.Dps.Domain.ValueObjects.Resources;

namespace Forge.Dps.Domain.ValueObjects.Attribution
{
    public class SecondaryAttributes
    {
        public Health Health { get; protected set; }
        public CriticalStrike CriticalStrike { get; protected set; }
        public Hit Hit { get; protected set; }
        public Dodge Dodge { get; protected set; }
        public Parry Parry { get; protected set; }
        public Defense Defense { get; protected set; }
        public BlockDamage BlockDamage { get; protected set; }
        public MeleeAttackPower MeleeAttackPower { get; protected set; }
        public RangedAttackPower RangedAttackPower { get; protected set; }
        public ArmorAmount Armor { get; protected set; }
        public WeaponSkills WeaponSkills { get; protected set; }
       
        public SecondaryAttributes(
            Health health,
            CriticalStrike criticalStrike, 
            Hit hit, 
            Dodge dodge,
            Parry parry, 
            Defense defense, 
            BlockDamage blockDamage,
            MeleeAttackPower meleeAttackPower,
            RangedAttackPower rangedAttackPower,
            ArmorAmount armor, 
            WeaponSkills weaponSkills)
        {
            Health = health;
            CriticalStrike = criticalStrike;
            Hit = hit;
            Dodge = dodge;
            Parry = parry;
            Defense = defense;
            BlockDamage = blockDamage;
            MeleeAttackPower = meleeAttackPower;
            RangedAttackPower = rangedAttackPower;
            Armor = armor;
            WeaponSkills = weaponSkills;
        }

        public SecondaryAttributes()
        {
            Health = Health.Zero;
            CriticalStrike = CriticalStrike.Zero;
            Hit = Hit.Zero;
            Dodge = Dodge.Zero;
            Parry = Parry.Zero;
            Defense = Defense.Zero;
            BlockDamage = BlockDamage.Zero;
            MeleeAttackPower = MeleeAttackPower.Zero;
            RangedAttackPower = RangedAttackPower.Zero;
            Armor = ArmorAmount.Zero;
            WeaponSkills = new WeaponSkills();
        }

        public SecondaryAttributes Combine(SecondaryAttributes otherSecondaryAttributes)
        {
            var combinedAttributes = new SecondaryAttributes(
                Health.Combine(Health, otherSecondaryAttributes.Health),
                new CriticalStrike(CriticalStrike.Value + otherSecondaryAttributes.CriticalStrike.Value),
                new Hit(Hit.Value + otherSecondaryAttributes.Hit.Value), 
                new Dodge(Dodge.Value + otherSecondaryAttributes.Dodge.Value), 
                new Parry(Parry.Value + otherSecondaryAttributes.Parry.Value),
                new Defense(Defense.Value + otherSecondaryAttributes.Defense.Value),
                new BlockDamage(BlockDamage.Value + otherSecondaryAttributes.BlockDamage.Value),
                new MeleeAttackPower(MeleeAttackPower.Value + otherSecondaryAttributes.MeleeAttackPower.Value),
                new RangedAttackPower(RangedAttackPower.Value + otherSecondaryAttributes.RangedAttackPower.Value),
                new ArmorAmount(Armor.Value + otherSecondaryAttributes.Armor.Value),
                WeaponSkills.Combine(WeaponSkills,otherSecondaryAttributes.WeaponSkills)
            );

            return combinedAttributes;
        }

    }
}