﻿using System.Linq;
using Cardify.Logic.Types;

namespace Cardify.Logic.CardScores
{
    public class HighestCardScore : ICardScoreCalculator
    {
        public CardSetScore Score(CardSet set)
        {
            int maxCardValue = set.Cards
                .Select(card => (int)card.Value)
                .DefaultIfEmpty(-1)
                .Max();

            return maxCardValue == -1 ? 
                new CardSetScore(Name) : 
                new CardSetScore(Name, maxCardValue);
        }

        public string Name => "HighestCard";
    }
}