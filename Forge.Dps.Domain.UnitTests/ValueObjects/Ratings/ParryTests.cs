using Forge.Dps.Domain.UnitTests.Doubles;
using NUnit.Framework;

namespace Forge.Dps.Domain.UnitTests.ValueObjects.Ratings
{
    public class ParryTests
    {
        [Test]
        public void ParryChance_Behind_Boss_ShouldBe_0()
        {
            var character = OrcWarrior.Level60();
            var target = Boss.Golemagg();

            var parryChance = target.CalculateParryChance(character, isBehindTarget: true);

            Assert.AreEqual(0, parryChance.Value);
        }

        [Test]
        public void ParryChance_InFrontOf_Boss_ShouldBe_14Percent()
        {
            var character = OrcWarrior.Level60();
            var target = Boss.Golemagg();

            var parryChance = target.CalculateParryChance(character, isBehindTarget: false);

            Assert.AreEqual(14.00f, parryChance.Value);
        }
    }
}
