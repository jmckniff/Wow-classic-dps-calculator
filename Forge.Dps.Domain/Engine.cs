using Forge.Dps.Domain.Aggregates;
using Forge.Dps.Domain.Entities;
using Forge.Dps.Domain.ValueObjects;
using Forge.Dps.Domain.ValueObjects.Attribution;
using Forge.Dps.Domain.ValueObjects.Classes;
using Forge.Dps.Domain.ValueObjects.Races;
using Forge.Dps.Domain.ValueObjects.Ratings;
using Forge.Dps.Domain.ValueObjects.Resources;

namespace Forge.Dps.Domain
{
    public class Engine
    {

        public void Run()
        {
            var target = new Mob(
                "Golemagg the Incinerator",
                new Health(826088),
                new Level(63),
                new Defense(315),
                new Dodge(0),
                Parry.Zero, 
                new ArmorAmount(4641));

            var level = new Level(60);
            var race = new Orc();
            var warrior = new Warrior(race, level);
            
            var equipment = new Equipment(null);
            var character = new Character(warrior, equipment);

            // figure out hit chance 
            // if target is 3 levels higher add one more %hit required.

            // 100% chance
            // take away target dodge (5%) account for difference in player weapon and target defense skills (source: https://github.com/magey/classic-warrior/wiki/Attack-table#dodge)
            // take away target parry (14%) account for difference in player weapon and target defense skills
            // take away block chance (5%) account for difference in player weapon and target defense skills  (source: https://github.com/magey/classic-warrior/wiki/Attack-table#block)
            // take away your chance to miss with main hand (two or one hander) (8%) (oponent defense vs your weapon skill + your hit rating) 
            // take away your chance to miss with offhand (when dual wielding) (24%) (oponent defense vs your weapon skill + your hit rating) 
            // glancing blows on white damage (40%) which causes (35% damage reduction if your weapon skill is less than target defense) (source: https://github.com/magey/classic-warrior/wiki/Attack-table#glancing-blows)
            // ====== hits from here
            // take away crit based on crit chance capped at hit chance
            // whatever is left is a hit

        }


    }
}
