using Forge.Dps.Domain.UnitTests.Doubles;
using NUnit.Framework;

namespace Forge.Dps.Domain.UnitTests.Entities
{
    public class MobTests
    {
        [Test]
        public void GlancingBlow_AgainstBoss_ShouldBe_40Percent()
        {
            var character = OrcWarrior.Level60();
            var target = Boss.Golemagg();

            var glancingBlowChance = target.CalculateGlancingBlowChance(character);

            Assert.AreEqual(40.0d, glancingBlowChance.Value);
            Assert.AreEqual(35.0d, glancingBlowChance.DamageReduction);
        }

        [Test]
        public void MissChance_AgainstBoss_ShouldBe_8Percent()
        {
            var character = OrcWarrior.Level60();
            var target = Boss.Golemagg();

            var missChance = target.CalculateMissChange(character);

            Assert.AreEqual(8d, missChance.Value);
        }
    }
}
