using System.Linq;
using Cardify.Logic.Types;

namespace Cardify.Logic.CardScores
{
    public class PairScore : PairScoreBase, ICardScoreCalculator
    {
        public string Name => "Pair";

        public CardSetScore Score(CardSet set)
        {
            var dictionary = set.Cards
                .GroupBy(card => card.Value, card => card)
                .ToDictionary(key => key.Key, val => val.ToList());

            bool isValid = dictionary.Values
                .Any(collection => collection.Count >= 2);

            if (isValid)
            {
                return new CardSetScore(Name, 1);
            }
            return new CardSetScore(Name);
        }
    }

    public class DoublePairScore : PairScoreBase, ICardScoreCalculator
    {
        public string Name => "Double Pair";

        public CardSetScore Score(CardSet set)
        {
            var dictionary = set.Cards
                .GroupBy(card => card.Value, card => card)
                .ToDictionary(key => key.Key, val => val.ToList());

            int count = dictionary
                .Count(kv => kv.Value.Count >= 2);

            if (count >= 2)
            {
                return new CardSetScore(Name, 2);
            }
            return new CardSetScore(Name);
        }
    }
}