using System.Collections.Generic;

namespace Forge.ItemData.File.Models
{
    public class ItemsFileModel
    {
        public List<ItemModel> Head { get; set; }
        public List<ItemModel> Neck { get; set; }
        public List<ItemModel> Shoulder { get; set; }
        public List<ItemModel> Back { get; set; }
        public List<ItemModel> Chest { get; set; }
        public List<ItemModel> Wrist { get; set; }
        public List<ItemModel> Hands { get; set; }
        public List<ItemModel> Waist { get; set; }
        public List<ItemModel> Legs { get; set; }
        public List<ItemModel> Feet { get; set; }
        public List<ItemModel> Rings { get; set; }
        public List<ItemModel> Trinkets { get; set; }
        public List<ItemModel> OneHandedWeapons { get; set; }
        public List<ItemModel> TwoHandedWeapons { get; set; }
        public List<ItemModel> RangedWeapons { get; set; }
    }
}
