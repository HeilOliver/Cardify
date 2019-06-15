using System.Linq;
using Cardify.Logic.Types;

namespace Cardify.Logic.CardScores
{
    public class FourOfAKindScore : PairScoreBase, ICardScoreCalculator
    {
        public string Name => "Four of a Kind";

        public CardSetScore Score(CardSet set)
        {
            var dictionary = set.Cards
                .GroupBy(card => card.Value, card => card)
                .ToDictionary(key => key.Key, val => val.ToList());

            bool isValid = dictionary.Values
                .Any(collection => collection.Count >= 4);

            if (isValid)
            {
                return new CardSetScore(Name, 8);
            }
            return new CardSetScore(Name);
        }
    }
}