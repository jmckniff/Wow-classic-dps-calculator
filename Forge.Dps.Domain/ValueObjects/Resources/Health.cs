namespace Forge.Dps.Domain.ValueObjects.Resources
{
    public class Health : Resource
    {
        public static Health Zero = new Health(0);

        public Health(int value) : base(value)
        {
        }

        public static Health Combine(Health health1, Health health2)
        {
            return new Health(health1.Value + health2.Value);
        }
    }
}
