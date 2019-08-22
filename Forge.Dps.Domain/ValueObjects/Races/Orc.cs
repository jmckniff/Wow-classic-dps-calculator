using Forge.Dps.Domain.ValueObjects.Attribution;

namespace Forge.Dps.Domain.ValueObjects.Races
{
    public class Orc : Race
    {
        public Orc() : base(RaceType.Orc)
        {
        }

        public override PrimaryAttributes GetBaseAttributes()
        {
            return new PrimaryAttributes(
                new Strength(23),
                new Agility(17), 
                new Stamina(22),
                new Intellect(17), 
                new Spirit(23));
        }
    }
}
