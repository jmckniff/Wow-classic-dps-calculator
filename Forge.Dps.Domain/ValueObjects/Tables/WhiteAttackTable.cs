using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Forge.Dps.Domain.ValueObjects.Ratings;

namespace Forge.Dps.Domain.ValueObjects.Tables
{
    public class WhiteAttackTable : IEnumerable<AttackTableRange>
    {
        private readonly List<AttackTableRange> _ranges;

        public WhiteAttackTable(
            Miss missChance,
            Dodge dodgeChance,
            Parry parryChance,
            GlancingBlow glancingBlowChance,
            CrushingBlow crushingBlowChance,
            Block blockChance,
            CriticalStrike criticalStrikeChance)
        {
            var chances = new List<Rating>
            {
                missChance,
                dodgeChance,
                parryChance,
                glancingBlowChance,
                crushingBlowChance,
                blockChance,
                criticalStrikeChance
            };

            _ranges = CalculateAttackTableRanges(chances);
        }

        private List<AttackTableRange> CalculateAttackTableRanges(IEnumerable<Rating> ratings)
        {
            var ranges = new List<AttackTableRange>();

            var position = 0d;

            foreach (var rating in ratings)
            {
                if (rating.Value == 0)
                {
                    ranges.Add(new EmptyAttackTableRange(rating));
                }
                else
                {
                    var min = position == 0 ? 0 : position + 0.1;
                    var max = Math.Clamp(min + rating.Value, 0, 100);
                    var range = new AttackTableRange(min, max, rating);

                    ranges.Add(range);

                    position = max;
                }
            }

            var hitChance = 100 - ranges.Sum(r => r.Result.Value);
            ranges.Add(new AttackTableRange(position + 0.1, 100, new Hit(hitChance)));

            return ranges;
        }

        public AttackTableRange Roll(double diceRoll)
        {
            return _ranges.First(r => r.Result.Value > 0.00 &&
                                      diceRoll >= r.Min &&
                                      diceRoll <= r.Max);
        }

        public IEnumerator<AttackTableRange> GetEnumerator()
        {
            return _ranges.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            var table = new StringBuilder();
            table.AppendLine("White Attack Table");

            foreach (var range in _ranges)
            {
                table.AppendLine(range.ToString());
            }

            return table.ToString();
        }
    }
}
