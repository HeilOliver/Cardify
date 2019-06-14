using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Cardify.Logic.CardScores;
using Cardify.Logic.CardScores.Validators;
using Cardify.Logic.Types;

namespace Cardify.Logic
{
    public class CardScoreManager
    {
        public CardSet HandCards { get; set; }

        public CardSet DeskCards { get; set; }


        private readonly ISet<ICardScoreCalculator> calculators = new HashSet<ICardScoreCalculator>()
        {
            new HighestCardScore(),
            new RoyalFlushScore(new SameColorValidator()),
            new FlushScore()
        };

        public CardScore CalculateScore()
        {
            if (HandCards == null || 
                DeskCards == null)
                return null;

            var cards = HandCards.Cards
                .Concat(DeskCards.Cards)
                .Distinct()
                .ToList();

            var cardSet = new CardSet(cards);

            var score = calculators
                .Select(calculator => calculator.Score(cardSet))
                .Where(result => result.IsValid)
                .OrderBy(result => result.Score)
                .FirstOrDefault();

            return score == null ? 
                null : 
                new CardScore(score.Name, score.Score);
        }
    }
}