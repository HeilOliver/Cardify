using Cardify.Logic.CardScores.Validators;
using Cardify.Logic.Types;

namespace Cardify.Logic.CardScores
{
    public class FlushScore : ICardScoreCalculator
    {
        private readonly ISetValidator validator;

        public FlushScore(ISetValidator validator)
        {
            this.validator = validator;
        }

        public CardSetScore Score(CardSet set)
        {
            bool isValid
                = validator.Validate(set);

            if (isValid)
                return new CardSetScore(Name, 5);

            return new CardSetScore(Name);
        }

        public string Name => "Flush";
    }
}