using Forge.Dps.Domain.UnitTests.Doubles;
using NUnit.Framework;

namespace Forge.Dps.Domain.UnitTests.Aggregates
{
    public class CharacterTests
    {
        [Test]
        public void Character_Attributes_ShouldNotBe_NotNull()
        {
            var character = OrcWarrior.Level60();

            Assert.NotNull(character.MainHandWeapon);
        }
    }
}
