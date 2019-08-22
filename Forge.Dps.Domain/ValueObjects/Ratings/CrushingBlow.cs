namespace Forge.Dps.Domain.ValueObjects.Ratings
{
    public class CrushingBlow : Rating
    {
        public static CrushingBlow Zero = new CrushingBlow(0);

        public CrushingBlow(double value) : base(value)
        {
           
        }
    }
}
