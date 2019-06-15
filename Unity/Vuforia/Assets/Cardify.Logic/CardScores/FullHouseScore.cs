using System.Linq;
using Cardify.Logic.Types;

namespace Cardify.Logic.CardScores
{
    public class FullHouseScore : PairScoreBase, ICardScoreCalculator
    {
        public string Name => "Full House";

        public CardSetScore Score(CardSet set)
        {
            var dictionary = set.Cards
                .GroupBy(card => card.Value, card => card)
                .ToDictionary(key => key.Key, val => val.ToList());

            bool foundPair = false;
            bool foundTribble = false;
            foreach (var value in dictionary.Values)
            {
                int valueCount = value.Count;

                if (!foundTribble && valueCount >= 3)
                {
                    foundTribble = true;
                    continue;
                }

                if (!foundPair && valueCount >= 2)
                {
                    foundPair = true;
                    continue;
                }
                break;
            }

            if (foundPair && foundTribble)
            {
                return new CardSetScore(Name, 7);
            }
            return new CardSetScore(Name);
        }
    }
}