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
            new FlushScore(new SameColorValidator()),
            new StraightFlushScore(new SameColorValidator()),
            new StreetScore(),
            new PairScore(),
            new DoublePairScore(),
            new FullHouseScore(),
            new FourOfAKindScore(),
            new ThreeOFAKindScore()
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

            bool sameColor = new SameColorValidator().Validate(cardSet);

            var score = calculators
                .Select(calculator => calculator.Score(cardSet))
                .Where(result => result.IsValid)
                .OrderByDescending(result => result.Score)
                .FirstOrDefault();

            string name = "";
            foreach (var setScore in calculators
                .Select(calculator => calculator.Score(cardSet))
                .Where(result => result.IsValid)
                .OrderByDescending(result => result.Score))
            {
                name = name + "\n -" + setScore.Name;
            }

            string cardText = "";
            foreach (var card in cards)
            {
             cardText = cardText + $"\n {card.Color}-{card.Value}";
            }

            name = $"Get - {cards.Count} - Same {sameColor}\n" + name;

            return score == null ? 
                null : 
                new CardScore(name, score.Score, cardText);
        }
    }
}