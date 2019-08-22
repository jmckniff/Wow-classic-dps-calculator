namespace Forge.Dps.Domain.ValueObjects.Resources
{
    public class Resource
    {
        public int Value { get; protected set; }

        public Resource(int value)
        {
            Value = value;
        }

        public static T Combine<T>(T a, T b) where T : Resource
        {
            return new Resource(a.Value + b.Value) as T;
        }
    }
}