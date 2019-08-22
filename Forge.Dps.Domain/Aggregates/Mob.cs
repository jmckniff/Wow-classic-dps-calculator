using System;
using Forge.Dps.Domain.Interfaces;
using Forge.Dps.Domain.ValueObjects;
using Forge.Dps.Domain.ValueObjects.Attribution;
using Forge.Dps.Domain.ValueObjects.Ratings;
using Forge.Dps.Domain.ValueObjects.Resources;

namespace Forge.Dps.Domain.Aggregates
{
    public class Mob : ICanBeTargeted
    {
        public string Name { get; }
        public Health Health { get; }
        public Level Level { get; }
        public Defense Defense { get; }
        public Dodge Dodge { get; }
        public Parry Parry { get; }
        public ArmorAmount Armor { get; }
        
        public Mob(
            string name,
            Health health,
            Level level, 
            Defense defense,
            Dodge dodge,
            Parry parry,
            ArmorAmount armor)
        {
            Name = name;
            Health = health;
            Level = level;
            Defense = defense;
            Dodge = dodge;
            Parry = parry;
            Armor = armor;
        }

        /// <summary>
        /// Calculates the chance for an attacker to critically strike the target.
        /// TODO Currently ONLY supports melee classes and mob targets.
        /// (source: https://github.com/magey/classic-warrior/wiki/Attack-table#critical-strike)
        /// </summary>
        public CriticalStrike CalculateCriticalStrikeChance(ICanAttack attacker)
        {
            var criticalStrikeChance = 0d;

            var baseAttackRating = Math.Min(attacker.Level.Value * 5, attacker.MainHandWeaponSkill.Value);
            var baseAttackRatingMinusTargeDefense = Defense.Value - baseAttackRating;

            // When the target is a mob you cannot apply more than [level * 5] points
            // of weapon skill toward your chance to get a critial hit.
            // This means at level 60 that level 61 and higher mobs are not
            // critically hit more often even if you increase your weapon skill above 300.
            baseAttackRating = Math.Clamp(baseAttackRating, 0, 300);

            // When the target is a mob and attack rating minus defense is less than 0,
            // the change is critical hit chance is 0.2 % per point of difference.

            // Beaza's crit chance formula:
            // If the target is a mob and BaseAttackRating minus TargetDefense is less than 0:
            // CritChance = AttackerCrit + (BaseAttackRating - TargetDefense) * 0.2 %
            if (baseAttackRatingMinusTargeDefense < 0)
            {
                criticalStrikeChance = attacker.CriticalStrike.Value + (baseAttackRating - Defense.Value) * 0.2;
            }

            // If the target is not a mob or the rating difference is above 0 then
            // the critical hit chance is adjusted 0.04 % per point of difference.

            // Beaza's crit chance formula:
            // If the target is a mob and BaseAttackRating minus TargetDefense is above or equal to 0:
            // CritChance = AttackerCrit + (BaseAttackRating - TargetDefense) * 0.04 %
            if (baseAttackRatingMinusTargeDefense >= 0)
            {
                criticalStrikeChance = attacker.CriticalStrike.Value + (baseAttackRating - Defense.Value) * 0.04;
            }

            return new CriticalStrike(criticalStrikeChance);
        }

        /// <summary>
        /// Calculates the chance a target has to dodge an attackers attack.
        /// TODO Currently ONLY supports melee classes and mob targets.
        /// (source: https://github.com/magey/classic-warrior/wiki/Attack-table#dodge)
        /// </summary>
        public Dodge CalculateDodgeChance(ICanAttack attacker)
        {
            // Each point of Defense over the attacker's Attack skill
            // adds 0.04% Dodge against players and 0.1% against mobs.
            // On the other hand, each point of Defense below the attacker's 
            // Attack skill cuts Dodge by 0.04 % against players and 0.1 % against mobs.

            // If the target is a mob:
            // DodgeChance = 5 % +(TargetLevel * 5 - AttackerSkill) * 0.1 %
            var dodgeChance = 5 + (Level.Value * 5 - attacker.MainHandWeaponSkill.Value) * 0.1;

            return new Dodge(dodgeChance);
        }

        /// <summary>
        /// Calculates the chance a target has to parry an attackers attack.
        /// TODO Currently ONLY supports melee classes and mob targets.
        /// (source: https://vanilla-wow.fandom.com/wiki/Parry)
        /// </summary>
        public Parry CalculateParryChance(ICanAttack attacker, bool isBehindTarget)
        {
            var targetLevelDifference = Level.Value - attacker.Level.Value;
            var parryChance = Parry.Value;

            if (targetLevelDifference == 3 && isBehindTarget == false)
            {
                // Creatures 3 levels higher than you have a 14% chance to Parry your attacks.
                parryChance = 14;
            }
            else if (targetLevelDifference > 0 && isBehindTarget == false)
            {
                // Creatures at your level have a 5% chance to Parry your attacks. 
                parryChance = 5;
            }

            return new Parry(parryChance);
        }

        /// <summary>
        /// Calculates the chance a target has to block an attackers attack.
        /// TODO Currently ONLY supports melee classes and mob targets.
        /// (source: https://github.com/magey/classic-warrior/wiki/Attack-table#block)
        /// </summary>
        public Block CalculateBlockChance(ICanAttack attacker)
        {
            // The base chance to block an attack is 5% and this is modified by a factor of the
            // rating difference between the attacker's weapon skill and the defender's defense.
            // Each point of difference adjusts the base chance by 0.1%
            // if the target is a mob and 0.04% if the target is a player.
            // Mobs level 9 and lower do not block as frequently,
            // just as they are not missed as frequently as they should be.
            // Also, mobs cannot block more than 5% of attacks regardless of rating difference.

            var skillDifference = Defense.Value - attacker.MainHandWeaponSkill.Value;
            var blockChance = 5.00d + (skillDifference * 0.1);

            blockChance = Math.Clamp(blockChance, 0, 5);

            return new Block(blockChance);
        }

        /// <summary>
        /// Calculates the chance the attackers attack will glance off the target.
        /// TODO Currently ONLY supports melee classes and mob targets.
        /// (source: https://github.com/magey/classic-warrior/wiki/Attack-table#glancing-blows)
        /// </summary>
        public GlancingBlow CalculateGlancingBlowChance(ICanAttack attacker)
        {
            // Players have a chance to perform a glancing blow against mobs
            // equal to 10 % plus 2 % per point of difference between attack rating and defense.

            // Beaza's formula for calculating Glancing Blow chance:
            // GlancingChance = 10% + (TargetLevel*5 - MIN(AttackerLevel*5 , AttackerSkill)) * 2%
            var baseGlancingBlowChance = 10.00;
            var skillDifference = (Level.Value * 5) - Math.Min(attacker.Level.Value * 5, attacker.MainHandWeaponSkill.Value);
            var glancingBlowChance = baseGlancingBlowChance + (skillDifference * 2);

            // Calculate the amount of damaged reduced by a Glancing Blow.
            // | ΔLevel | Chance to occur | Base damage penalty |
            // |   0    |       10%       |         5%          |
            // |   1    |       20%       |         5%          |
            // |   2    |       30%       |         15%         |
            // |   3    |       40%       |         35%         |

            // Beaza's Glacing Blow damage reduction formula:
            // Low end: 1.3 - 0.05*(defense-skill) capped at 0.91
            // High end: 1.2 - 0.03 * (defense - skill) min of 0.2 and capped at 0.99
            // Average Reduction: (high + low) / 2

            var lowEnd = 1.3 - (0.05 * skillDifference);
            lowEnd = Math.Clamp(lowEnd, 0.01, 0.91);

            var highEnd = 1.2 - (0.03 * skillDifference);
            highEnd = Math.Clamp(highEnd, 0.2, 0.99);

            var averageDamageReduction = (highEnd + lowEnd) / 2;
            var damageReductionPercent = (1 - averageDamageReduction) * 100;
            
            return new GlancingBlow(glancingBlowChance, damageReductionPercent);
        }

        public Miss CalculateMissChange(ICanAttack attacker)
        {
            var missChance = 0d;
            var skillDifference = Defense.Value - attacker.MainHandWeaponSkill.Value;

            // If the target is a mob and defense minus attack rating is 11 or more:
            // MissChance = 5 % +(TargetLevel * 5 - AttackerSkill) * 0.2 %
            if (skillDifference >= 11)
            {
                missChance = 5 + (Level.Value * 5 - attacker.MainHandWeaponSkill.Value) * 0.2;
            }
            
            //If the target is a mob and defense minus attack rating is 10 or less:
            // MissChance = 5 % +(TargetLevel * 5 - AttackerSkill) * 0.1 %
            if (skillDifference <= 10)
            {
                missChance = 5 + (Level.Value * 5 - attacker.MainHandWeaponSkill.Value) * 0.1;
            }

            // If the target is a mob below level 10:
            // MissChance = NormalMissChance * (TargetLevel / 10)
            if (skillDifference < 10)
            {
                missChance = 5 * (Level.Value / 10);
            }

            // If the target is a player:
            // MissChance = 5 % +(PlayerDefense - AttackerSkill) * 0.04 %

            return new Miss(missChance);
        }

    }
}
