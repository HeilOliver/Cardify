using System.Linq;
using Cardify.Logic.Types;

namespace Cardify.Logic.CardScores
{
    public class ThreeOFAKindScore : PairScoreBase, ICardScoreCalculator
    {
        public string Name => "Three Of A Kind";

        public CardSetScore Score(CardSet set)
        {
            var groups = GroupCardSet(set);
            bool threeOfAKind = groups.Select(kv => kv.Value).Any(a => a.Count > 3);
            if (threeOfAKind)
            {
                return new CardSetScore(Name, 4);
            }
            return new CardSetScore(Name);
        }
    }
}