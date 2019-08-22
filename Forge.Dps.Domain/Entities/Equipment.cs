using System.Collections.Generic;
using Forge.Dps.Domain.ValueObjects.Attribution;
using Forge.Dps.Domain.ValueObjects.Items;

namespace Forge.Dps.Domain.Entities
{
    public class Equipment
    {
        public PrimaryAttributes PrimaryAttributes { get; }
        public SecondaryAttributes SecondaryAttributes { get; }

        private readonly Dictionary<SlotType, Item> _items;
        
        public Equipment(Dictionary<SlotType, Item> items)
        {
            _items = items;
            PrimaryAttributes = CalculatePrimaryAttributes(items);
            SecondaryAttributes = CalculateSecondaryAttributes(items);
        }

        public Weapon MainHandWeapon => _items[SlotType.MainHand] as Weapon;
        public Weapon OffHandWeapon => _items[SlotType.OffHand] as Weapon;

        public IReadOnlyDictionary<SlotType, Item> GetItems()
        {
            return _items;
        }

        public Item GetItem(SlotType slotType)
        {
            return _items[slotType];
        }

        private PrimaryAttributes CalculatePrimaryAttributes(Dictionary<SlotType, Item> items)
        {
            var primaryAttributes = new PrimaryAttributes();

            foreach (var (slot, item) in items)
            {
                primaryAttributes.Strength.Add(item.PrimaryAttributes.Strength.Value);
                primaryAttributes.Agility.Add(item.PrimaryAttributes.Agility.Value);
                primaryAttributes.Stamina.Add(item.PrimaryAttributes.Stamina.Value);
                primaryAttributes.Intellect.Add(item.PrimaryAttributes.Intellect.Value);
                primaryAttributes.Spirit.Add(item.PrimaryAttributes.Spirit.Value);
            }

            return primaryAttributes;
        }

        private SecondaryAttributes CalculateSecondaryAttributes(Dictionary<SlotType, Item> items)
        {
            var secondaryAttributes = new SecondaryAttributes();
            
            foreach (var (slot, item) in items)
            {
                secondaryAttributes.CriticalStrike.Add(item.SecondaryAttributes.CriticalStrike.Value);
                secondaryAttributes.Hit.Add(item.SecondaryAttributes.Hit.Value);
                secondaryAttributes.Dodge.Add(item.SecondaryAttributes.Dodge.Value);
                secondaryAttributes.Parry.Add(item.SecondaryAttributes.Parry.Value);
                secondaryAttributes.Defense.Add(item.SecondaryAttributes.Defense.Value);
                secondaryAttributes.MeleeAttackPower.Add(item.SecondaryAttributes.MeleeAttackPower.Value);
                secondaryAttributes.Armor.Add(item.SecondaryAttributes.Armor.Value);

                foreach (var weaponSkill in item.SecondaryAttributes.WeaponSkills)
                {
                    secondaryAttributes.WeaponSkills.Add(weaponSkill);
                }
            }

            return secondaryAttributes;
        }
    }
}