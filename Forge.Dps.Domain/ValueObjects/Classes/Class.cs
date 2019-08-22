using Forge.Dps.Domain.Entities;
using Forge.Dps.Domain.ValueObjects.Attribution;
using Forge.Dps.Domain.ValueObjects.Races;

namespace Forge.Dps.Domain.ValueObjects.Classes
{
    public abstract class Class
    {
        public Race Race { get; }
        public Level Level { get; }
        public PrimaryAttributes PrimaryAttributes { get; protected set; }
        public SecondaryAttributes SecondaryAttributes { get; protected set; }

        protected Class(Race race, Level level)
        {
            Race = race;
            Level = level;
            PrimaryAttributes = new PrimaryAttributes();
            SecondaryAttributes = new SecondaryAttributes();
        }

        public abstract SecondaryAttributes CalculateSecondaryAttributes(PrimaryAttributes primaryAttributes);
    }
}