using Forge.Dps.Domain.ValueObjects.Attribution;

namespace Forge.Dps.Domain.ValueObjects.Races
{
    public abstract class Race
    {
        public RaceType Type { get; private set; }

        public Race(RaceType type)
        {
            Type = type;
        }

        public abstract PrimaryAttributes GetBaseAttributes();

    }
}