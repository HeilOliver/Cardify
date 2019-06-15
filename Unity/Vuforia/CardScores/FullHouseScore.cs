using System.Linq;
using Cardify.Logic.Types;

namespace Cardify.Logic.CardScores
{
    public class FullHouseScore : PairScoreBase, ICardScoreCalculator
    {
        public string Name => "Full House";

        public CardSetScore Score(CardSet set)
        {
            var groups = GroupCardSet(set);
            bool fourOfAKind = groups.Select(kv => kv.Value).Any(a => a.Count > 2 && groups.Select(kv => kv.Value).Any(b => b.Count > 3));
            if (fourOfAKind)
            {
                return new CardSetScore(Name, 4);
            }
            return new CardSetScore(Name);
        }
    }
}