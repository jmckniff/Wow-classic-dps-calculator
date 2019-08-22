namespace Forge.Dps.Domain.Extensions
{
    public static class DoubleExtensions
    {
        public static double ToTwoDecimalPlaces(this double value)
        {
            return double.Parse($"{value:0.00}");
        }
    }
}
