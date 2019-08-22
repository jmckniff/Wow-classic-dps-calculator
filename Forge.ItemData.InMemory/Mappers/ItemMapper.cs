using Forge.Dps.Domain.Entities;
using Forge.Dps.Domain.ValueObjects;
using Forge.Dps.Domain.ValueObjects.Attribution;
using Forge.Dps.Domain.ValueObjects.Items;
using Forge.Dps.Domain.ValueObjects.Ratings;
using Forge.Dps.Domain.ValueObjects.Resources;
using Forge.ItemData.File.Models;

namespace Forge.ItemData.File.Mappers
{
    public class ItemMapper
    {
        public Item MapFrom(ItemModel model)
        {
            var item = new Item(
                model.Name,
                new ItemIdentifier(model.Name),
                new PrimaryAttributes(
                    new Strength(model.Strength),
                    new Agility(model.Agility),
                    new Stamina(model.Stamina),
                    Intellect.Zero,
                    Spirit.Zero), 
                new SecondaryAttributes(
                    Health.Zero, 
                    new CriticalStrike(model.Crit),
                    new Hit(model.Hit),
                    new Dodge(model.Dodge),
                    new Parry(model.Parry),
                    new Defense(model.Defense),
                    BlockDamage.Zero,
                    new MeleeAttackPower(model.AP),
                    new RangedAttackPower(model.AP),
                    new ArmorAmount(model.AC),
                    new WeaponSkills())
                );

            return item;
        }
    }
}
