using Forge.Dps.Domain.UnitTests.Doubles;
using NUnit.Framework;

namespace Forge.Dps.Domain.UnitTests.ValueObjects.Ratings
{
    public class CriticalStrikeTests
    {
        [Test]
        public void CritChance_AgainstBoss_ShouldBe_23Percent()
        {
            var character = OrcWarrior.Level60();
            var target = Boss.Golemagg();

            var criticalStrikeChance = target.CalculateCriticalStrikeChance(character);

            Assert.AreEqual(14.8d, criticalStrikeChance.Value);
        }

    }
}
