namespace Forge.Dps.Domain.ValueObjects.Attribution
{
    public class CharacterAttributes
    {
        public SecondaryAttributes ClassSecondaryAttributes { get; private set; }
        public SecondaryAttributes EquipmentSecondaryAttributes { get; private set; }

        public CharacterAttributes(
            SecondaryAttributes classSecondaryAttributes,
            SecondaryAttributes equipmentSecondaryAttributes)
        {
            ClassSecondaryAttributes = classSecondaryAttributes;
            EquipmentSecondaryAttributes = equipmentSecondaryAttributes;
        }
    }
}