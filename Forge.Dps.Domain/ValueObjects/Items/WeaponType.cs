namespace Forge.Dps.Domain.ValueObjects.Items
{
    public class WeaponType
    {
        public WeaponCategory Category { get; private set; }
        public Handedness Handedness { get; private set; }

        public WeaponType(WeaponCategory category, Handedness handedness)
        {
            Category = category;
            Handedness = handedness;
        }
    }
}