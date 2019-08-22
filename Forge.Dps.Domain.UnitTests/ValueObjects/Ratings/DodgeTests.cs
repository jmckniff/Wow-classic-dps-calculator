using Forge.Dps.Domain.UnitTests.Doubles;
using NUnit.Framework;

namespace Forge.Dps.Domain.UnitTests.ValueObjects.Ratings
{
    public class DodgeTests
    {
        [Test]
        public void DodgeChance_AgainstBoss_ShouldBe_6point5Percent()
        {
            var character = OrcWarrior.Level60();
            var target = Boss.Golemagg();

            var dodgeChance = target.CalculateDodgeChance(character);

            Assert.AreEqual(6.50f, dodgeChance.Value);
        }
    }
}
