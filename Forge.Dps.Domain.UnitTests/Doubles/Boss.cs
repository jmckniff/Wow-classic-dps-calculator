using Forge.Dps.Domain.Aggregates;
using Forge.Dps.Domain.ValueObjects;
using Forge.Dps.Domain.ValueObjects.Attribution;
using Forge.Dps.Domain.ValueObjects.Ratings;
using Forge.Dps.Domain.ValueObjects.Resources;

namespace Forge.Dps.Domain.UnitTests.Doubles
{
    public class Boss
    {
        public static Mob Golemagg()
        {
            return new Mob(
                "Golemagg the Incinerator",
                new Health(826088),
                new Level(63),
                new Defense(315),
                new Dodge(0),
                Parry.Zero,
                new ArmorAmount(4641));
        }
    }
}
