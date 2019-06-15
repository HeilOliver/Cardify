using System.Collections.Generic;
using System.Linq;
using Cardify.Logic.Types;

namespace Cardify.Logic.CardScores
{
    public class PairScoreBase
    {
        public IDictionary<CardValue, List<Card>> GroupCardSet(CardSet cardSet)
        {
            var cardValue = cardSet.Cards
                .GroupBy(card => card.Value, card => card, (key, g) => new { key, g });

            return cardValue.ToDictionary(card => card.key, card => card.g.ToList());
        }
    }
}