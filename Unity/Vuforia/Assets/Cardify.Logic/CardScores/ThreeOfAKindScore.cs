using System.Linq;
using Cardify.Logic.Types;

namespace Cardify.Logic.CardScores
{
    public class ThreeOFAKindScore : PairScoreBase, ICardScoreCalculator
    {
        public string Name => "Three Of A Kind";

        public CardSetScore Score(CardSet set)
        {
            var dictionary = set.Cards
                .GroupBy(card => card.Value, card => card)
                .ToDictionary(key => key.Key, val => val.ToList());

            bool isValid = dictionary.Values
                .Any(collection => collection.Count >= 3);

            if (isValid)
            {
                return new CardSetScore(Name, 4);
            }
            return new CardSetScore(Name);
        }
    }
}