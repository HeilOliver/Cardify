﻿using Cardify.Logic.CardScores.Validators;
using Cardify.Logic.Types;

namespace Cardify.Logic.CardScores
{
    public class StraightFlushScore : StreetScore, ICardScoreCalculator
    {
        private readonly ISetValidator colorValidator;

        public new string Name => "Straight Flush";

        public StraightFlushScore(ISetValidator colorValidator)
        {
            this.colorValidator = colorValidator;
        }

        public new CardSetScore Score(CardSet set)
        {
            bool validate = colorValidator.Validate(set);
            var score = base.Score(set);

            return validate && score.IsValid ? 
                new CardSetScore(Name, 9) : 
                new CardSetScore(Name);
        }
    }
}