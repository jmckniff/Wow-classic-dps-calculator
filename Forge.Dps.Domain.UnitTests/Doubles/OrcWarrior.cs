using System.Collections.Generic;
using Forge.Dps.Domain.Aggregates;
using Forge.Dps.Domain.Entities;
using Forge.Dps.Domain.ValueObjects;
using Forge.Dps.Domain.ValueObjects.Classes;
using Forge.Dps.Domain.ValueObjects.Items;
using Forge.Dps.Domain.ValueObjects.Races;
using Forge.ItemData.File;

namespace Forge.Dps.Domain.UnitTests.Doubles
{
    public class OrcWarrior
    {
        public static Character Level60()
        {
            var itemRepository = new InMemoryFindItems();
            var items = new Dictionary<SlotType, Item>
            {
                {SlotType.Helmet, itemRepository.FindByName("Lionheart Helm") },
                {SlotType.Neck, itemRepository.FindByName("Barbed Choker") },
                {SlotType.Shoulder, itemRepository.FindByName("Conqueror's Spaulders") },
                {SlotType.Back, itemRepository.FindByName("Cloak of Concentrated Hatred") },
                {SlotType.Chest, itemRepository.FindByName("Breastplate of Annihilation") },
                {SlotType.Wrist, itemRepository.FindByName("Hive Defiler Wristguards") },
                {SlotType.Waist, itemRepository.FindByName("Onslaught Girdle") },
                {SlotType.Legs, itemRepository.FindByName("Conqueror's Legguards") },
                {SlotType.Feet, itemRepository.FindByName("Chromatic Boots") },
                {SlotType.Ring1, itemRepository.FindByName("Master Dragonslayer's Ring") },
                {SlotType.Ring2, itemRepository.FindByName("Quick Strike Ring") },
                {SlotType.Trinket1, itemRepository.FindByName("Drake Fang Talisman")},
                {SlotType.Trinket2, itemRepository.FindByName("Hand of Justice")},
                {SlotType.MainHand, itemRepository.FindByName("R14 Longsword")},
                {SlotType.Ranged, itemRepository.FindByName("Striker's Mark")}
            };

            var level = new Level(60);
            var race = new Orc();
            var warrior = new Warrior(race, level);

            var equipment = new Equipment(items);
            var character = new Character(warrior, equipment);

            return character;
        }
    }
}
