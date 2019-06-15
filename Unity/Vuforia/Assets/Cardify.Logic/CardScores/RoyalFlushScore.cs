﻿using System.Linq;
using Cardify.Logic.CardScores.Validators;
using Cardify.Logic.Types;

namespace Cardify.Logic.CardScores
{
    public class RoyalFlushScore : ICardScoreCalculator
    {
        private readonly ISetValidator colorValidator;

        public RoyalFlushScore(ISetValidator colorValidator)
        {
            this.colorValidator = colorValidator;
        }

        public CardSetScore Score(CardSet set)
        {
            bool sameColor = colorValidator.Validate(set);

            if (!sameColor)
                return new CardSetScore(Name);

            if (set.Cards
                    .Select(card => card.Value)
                    .Distinct()
                    .ToList().Count != 5)
                return new CardSetScore(Name);

            bool valid = set.Cards.All(Validate);

            return valid ? 
                new CardSetScore(Name, 12) : 
                new CardSetScore(Name);
        }

        public string Name => "RoyalFlush";

        private bool Validate(Card card)
        {
            var cardValue = card.Value;

            if (cardValue == CardValue.Ace)
                return true;

            if (cardValue == CardValue.King)
                return true;

            if (cardValue == CardValue.Queen)
                return true;

            if (cardValue == CardValue.Jack)
                return true;

            if (cardValue == CardValue.Ten)
                return true;

            return false;
        }
    }
}