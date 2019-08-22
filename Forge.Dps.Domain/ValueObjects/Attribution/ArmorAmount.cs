namespace Forge.Dps.Domain.ValueObjects.Attribution
{
    public class ArmorAmount : Attribute
    {
        public static ArmorAmount Zero => new ArmorAmount(0);

        public ArmorAmount(double value) : base(value)
        {
        }
    }
}
