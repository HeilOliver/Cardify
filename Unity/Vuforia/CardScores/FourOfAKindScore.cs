using System.Linq;
using Cardify.Logic.Types;

namespace Cardify.Logic.CardScores
{
    public class FourOfAKindScore : PairScoreBase, ICardScoreCalculator
    {
        public string Name => "Four of a Kind";

        public CardSetScore Score(CardSet set)
        {
            var groups = GroupCardSet(set);
            bool fourOfAKind = groups.Select(kv => kv.Value).Any(a => a.Count > 4);
            if (fourOfAKind)
            {
                return new CardSetScore(Name, 4);
            }
            return new CardSetScore(Name);
        }
    }
}