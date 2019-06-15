using System.Linq;
using Cardify.Logic.Types;

namespace Cardify.Logic.CardScores
{
    public class StreetScore : ICardScoreCalculator
    {
        public CardSetScore Score(CardSet set)
        {
            var cards = set.Cards
                .OrderBy(card => card.Value)
                .ToList();

            if (!cards.Any())
                return new CardSetScore(Name);

            var singleValues = cards
                .Select(card => card.Value)
                .Distinct()
                .ToList();

            if (singleValues.Contains(CardValue.Ace))
                singleValues.Insert(0, CardValue.Ace);

            int streetCount = 0;
            for (int i = 0; i < singleValues.Count - 1; i++)
            {
                int currentCard = (int) singleValues[i];
                int nextCard = (int) singleValues[i +1];

                if (i == 0 && singleValues[0] == CardValue.Ace)
                {
                    currentCard = 0;
                }

                if (streetCount == 4)
                    break;

                if ((currentCard) + 1 == nextCard)
                {
                    streetCount++;
                    continue;
                }
        
                streetCount = 0;
            }

            return streetCount == 4 ? 
                new CardSetScore(Name, 6) : 
                new CardSetScore(Name);
        }

        public string Name => "Street";
    }
}