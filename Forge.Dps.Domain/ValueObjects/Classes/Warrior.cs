using Forge.Dps.Domain.ValueObjects.Attribution;
using Forge.Dps.Domain.ValueObjects.Races;
using Forge.Dps.Domain.ValueObjects.Ratings;
using Forge.Dps.Domain.ValueObjects.Resources;

namespace Forge.Dps.Domain.ValueObjects.Classes
{
    public class Warrior : Class
    {
        public Rage Rage { get; }

        public Warrior(Race race, Level level) : base(race, level)
        {
            Rage = new Rage(100);
            PrimaryAttributes = CalculatePrimaryAttributes(level);
            SecondaryAttributes = CalculateSecondaryAttributes(PrimaryAttributes);

            // 5 point Defense cap increase per level, we are assuming maximum is achieved.
            SecondaryAttributes.Defense.Add(Level.Value * 5);
            // Get all weapon skills, capped at the maximum for the players level.
            var maxWeaponSkillsForLevel = WeaponSkill.GetWeaponSkills(Level);
            SecondaryAttributes.WeaponSkills.Add(maxWeaponSkillsForLevel);
        }

        /// <summary>
        /// Calculate secondary attributes from primary attributes.
        /// i.e. How much critical strike chance does the characters agility provide?
        /// </summary>
        public override SecondaryAttributes CalculateSecondaryAttributes(PrimaryAttributes primaryAttributes)
        {
            // (Source: https://rankedboost.com/world-of-warcraft/classic-stats/)
            // 2 Melee Attack Power per 1 point of Strength.
            var meleeAttackPower = new MeleeAttackPower(primaryAttributes.Strength.Value * 2);
            // Block 1 Damage for every 20 points of Strength.
            var blockDamage = new BlockDamage(primaryAttributes.Strength.Value / 20);
            // 2 Armor for every 1 point of Agility.
            var armor = new ArmorAmount(primaryAttributes.Agility.Value / 2);
            // 1% Critical Strike Chance for every 20 points of Agility.
            var criticalStrike = new CriticalStrike(primaryAttributes.Agility.Value / 20);
            // 1 Ranged Attack Power per 1 point of Agility.
            var rangedAttackPower = new RangedAttackPower(primaryAttributes.Agility.Value);
            // 1% Dodge per 20 point of Agility.
            var dodge = new Dodge(primaryAttributes.Agility.Value / 20);
            // 5% base chance to Parry. (Source: https://worldofwarcraft.fandom.com/et/wiki/Parry)
            var parry = new Parry(5);
            // 10 Health for every 1 point of Stamina.
            var health = new Health((int)primaryAttributes.Stamina.Value / 10);

            var attributes = new SecondaryAttributes(
                health,
                criticalStrike,
                Hit.Zero,
                dodge,
                parry,
                Defense.Zero, 
                blockDamage,
                meleeAttackPower,
                rangedAttackPower,
                armor,
                new WeaponSkills());

            return attributes;
        }

        /// <summary>
        /// Calculate the primary stats for the character at the specified level.
        /// This includes class and race base attributes.
        /// </summary>
        private PrimaryAttributes CalculatePrimaryAttributes(Level level)
        {
            var classPrimaryAttributes = GetClassBasePrimaryAttributes();
            var racePrimaryAttributes = Race.GetBaseAttributes();
            var levelPrimaryAttributes = GetPrimaryAttributesForLevel(level.Value);

            return new PrimaryAttributes()
                .Combine(classPrimaryAttributes)
                .Combine(racePrimaryAttributes)
                .Combine(levelPrimaryAttributes);
        }

        private PrimaryAttributes GetClassBasePrimaryAttributes()
        {
            return new PrimaryAttributes(
                new Strength(3),
                Agility.Zero,
                new Stamina(2),
                Intellect.Zero,
                Spirit.Zero);
        }

        private PrimaryAttributes GetPrimaryAttributesForLevel(double level)
        {
            var baseAttributes = new PrimaryAttributes();
            var baseAttributesTable = new WarriorBaseAttributesTable();

            for(var currentLevel = 1; currentLevel <= level; currentLevel++)
            {
                var attributesGained = baseAttributesTable[currentLevel];
                baseAttributes = new PrimaryAttributes()
                    .Combine(baseAttributes)
                    .Combine(attributesGained);
            }

            return baseAttributes;
        }
    }
}
