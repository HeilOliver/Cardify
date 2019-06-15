using System.Linq;
using Cardify.Logic.Types;

namespace Cardify.Logic.CardScores
{
    public class PairScore : PairScoreBase, ICardScoreCalculator
    {
        public string Name => "Pair";

        public CardSetScore Score(CardSet set)
        {
            var groups = GroupCardSet(set);
            bool pair = groups.Select(kv => kv.Value).Any(a => a.Count > 2);
            if (pair)
            {
                return new CardSetScore(Name, 4);
            }
            return new CardSetScore(Name);
        }
    }
}