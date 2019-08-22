namespace Forge.Dps.Domain.ValueObjects.Items
{
    public class WeaponProc
    {
        public static WeaponProc None => null;

        public WeaponProc(string name, double dps, string description)
        {
            Name = name;
            Description = description;
            Dps = dps;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Dps { get; private set; }
    }
}
