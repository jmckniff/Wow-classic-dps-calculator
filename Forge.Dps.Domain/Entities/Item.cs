using Forge.Dps.Domain.ValueObjects;
using Forge.Dps.Domain.ValueObjects.Attribution;
using Forge.Dps.Domain.ValueObjects.Items;

namespace Forge.Dps.Domain.Entities
{
    public class Item
    {
        public string Id => _identifier.Id;
        public string Name { get; }
        public PrimaryAttributes PrimaryAttributes { get; }
        public SecondaryAttributes SecondaryAttributes { get; }

        private readonly ItemIdentifier _identifier;

        public Item(
            string name,
            ItemIdentifier identifier,
            PrimaryAttributes primaryAttributes,
            SecondaryAttributes secondaryAttributes)
        {
            _identifier = identifier;
            Name = name;
            PrimaryAttributes = primaryAttributes;
            SecondaryAttributes = secondaryAttributes;
        }
    }
}
