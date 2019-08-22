using System;
using System.Linq;
using Forge.Dps.Domain.UnitTests.Doubles;
using Forge.Dps.Domain.ValueObjects.Ratings;
using Forge.Dps.Domain.ValueObjects.Tables;
using NUnit.Framework;

namespace Forge.Dps.Domain.UnitTests.ValueObjects.Ratings
{
    public class AttackTableTests
    {
        [Test]
        public void AttackTable_SumOf_AttackResults_Is_100Percent()
        {
            var character = OrcWarrior.Level60();
            var target = Boss.Golemagg();
            
            var criticalStrikeChance = target.CalculateCriticalStrikeChance(character);
            var missChance = target.CalculateMissChange(character);
            var parryChance = target.CalculateParryChance(character, true);
            var dodgeChance = target.CalculateDodgeChance(character);
            var blockChance = target.CalculateBlockChance(character);
            var glancingChance = target.CalculateGlancingBlowChance(character);

            var attackTable = new WhiteAttackTable(
                missChance,
                dodgeChance,
                parryChance,
                glancingChance,
                CrushingBlow.Zero,
                blockChance,
                criticalStrikeChance);

            var random = new Random();

            Console.Write(attackTable.ToString());

            var totalChance = attackTable.Sum(r => r.Result.Value);

            Assert.AreEqual(100, totalChance);
        }


    }

}
