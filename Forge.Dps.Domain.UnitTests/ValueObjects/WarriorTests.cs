using Forge.Dps.Domain.UnitTests.Doubles;
using NUnit.Framework;

namespace Forge.Dps.Domain.UnitTests.ValueObjects
{
    public class WarriorTests
    {
        [Test]
        public void Level60_Orc_Warrior_ShouldHave_Correct_Attributes()
        {
            var warrior = OrcWarrior.Level60();

            var attributes = warrior.Class.PrimaryAttributes;

            Assert.AreEqual(123, attributes.Strength.Value);
            Assert.AreEqual(77, attributes.Agility.Value);
            Assert.AreEqual(112, attributes.Stamina.Value);
            Assert.AreEqual(17, attributes.Intellect.Value);
            Assert.AreEqual(48, attributes.Spirit.Value);
        }
    }
}
