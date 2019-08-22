namespace Forge.Dps.Domain.ValueObjects.Items
{
    public class ItemIdentifier
    {
        public ItemIdentifier(string id)
        {
            Id = id;
        }

        public string Id { get; private set; }

    }
}
