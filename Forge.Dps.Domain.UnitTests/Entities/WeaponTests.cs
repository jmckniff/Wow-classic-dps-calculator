using Forge.Dps.Domain.Entities;
using Forge.Dps.Domain.ValueObjects;
using Forge.Dps.Domain.ValueObjects.Attribution;
using Forge.Dps.Domain.ValueObjects.Items;
using Forge.Dps.Domain.ValueObjects.Ratings;
using Forge.Dps.Domain.ValueObjects.Resources;
using NUnit.Framework;

namespace Forge.Dps.Domain.UnitTests.Entities
{
    public class WeaponTests
    {
        [Test]
        public void ArcaniteReaper_ShouldHave_Correct_Dps()
        {
            var weapon = new Weapon(
                "Arcanite Reaper",
                new ItemIdentifier(""),
                new PrimaryAttributes(
                    Strength.Zero,
                    Agility.Zero,
                    new Stamina(13),
                    Intellect.Zero,
                    Spirit.Zero), 
                new SecondaryAttributes(
                    Health.Zero,
                    CriticalStrike.Zero,
                    Hit.Zero,
                    Dodge.Zero,
                    Parry.Zero,
                    Defense.Zero,
                    BlockDamage.Zero, 
                    new MeleeAttackPower(62),
                    RangedAttackPower.Zero,  
                    ArmorAmount.Zero,
                    new WeaponSkills()), 
                new WeaponType(WeaponCategory.Axe, Handedness.TwoHanded),
                new DamageRange(153, 256),
                3.80d,
                WeaponProc.None
            );

            var dps = weapon.CalculateDps();
            

            Assert.AreEqual(new DamagePerSecond(53.82d).Value, dps.Value);
        }
    }
}