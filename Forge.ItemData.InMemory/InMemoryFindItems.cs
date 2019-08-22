using System.Collections.Generic;
using System.Linq;
using Forge.Dps.Domain.Entities;
using Forge.Dps.Domain.Interfaces;
using Forge.Dps.Domain.ValueObjects.Items;
using Forge.ItemData.File.Mappers;
using Forge.ItemData.File.Models;
using Newtonsoft.Json;

namespace Forge.ItemData.File
{
    public class InMemoryFindItems : IFindItems
    {
        private readonly List<Item> _items;

        public InMemoryFindItems()
        {
            var itemsFile = LoadItemsFile();
            _items = MapItemsFromItemsFile(itemsFile);
        }

        public Item FindByName(string itemName)
        {
            return _items.FirstOrDefault(item => item.Name.ToLower() == itemName.ToLower());
        }

        private ItemsFileModel LoadItemsFile()
        {
            var fileName = "items.json";
            var json = System.IO.File.ReadAllText(fileName);
            var itemsFile = JsonConvert.DeserializeObject<ItemsFileModel>(json);
            return itemsFile;
        }

        private List<Item> MapItemsFromItemsFile(ItemsFileModel itemsFile)
        {
            var items = new List<Item>();
            
            foreach (var property in typeof(ItemsFileModel).GetProperties())
            {
                items.AddRange(GetItems(itemsFile.Head));
                items.AddRange(GetItems(itemsFile.Neck));
                items.AddRange(GetItems(itemsFile.Shoulder));
                items.AddRange(GetItems(itemsFile.Back));
                items.AddRange(GetItems(itemsFile.Chest));
                items.AddRange(GetItems(itemsFile.Wrist));
                items.AddRange(GetItems(itemsFile.Waist));
                items.AddRange(GetItems(itemsFile.Hands));
                items.AddRange(GetItems(itemsFile.Legs));
                items.AddRange(GetItems(itemsFile.Feet));
                items.AddRange(GetItems(itemsFile.Rings));
                items.AddRange(GetItems(itemsFile.Trinkets));
                items.AddRange(GetWeapons(itemsFile.OneHandedWeapons, Handedness.OneHanded));
                items.AddRange(GetWeapons(itemsFile.TwoHandedWeapons, Handedness.TwoHanded));
                items.AddRange(GetWeapons(itemsFile.RangedWeapons, Handedness.NotApplicable));
            }

            return items;
        }

        private List<Item> GetItems(List<ItemModel> itemModels)
        {
            var items = new List<Item>();
            var mapper = new ItemMapper();
            foreach (var itemModel in itemModels)
            {
                var item = mapper.MapFrom(itemModel);
                items.Add(item);
            }

            return items;
        }

        private List<Item> GetWeapons(List<ItemModel> itemModels, Handedness handedness)
        {
            var items = new List<Item>();
            var mapper = new WeaponMapper();
            foreach (var itemModel in itemModels)
            {
                var item = mapper.MapFrom(itemModel, handedness);
                items.Add(item);
            }

            return items;
        }
    }
}
