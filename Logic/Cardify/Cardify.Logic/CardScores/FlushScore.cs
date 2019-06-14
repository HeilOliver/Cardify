using Cardify.Logic.CardScores.Validators;
using Cardify.Logic.Types;

namespace Cardify.Logic.CardScores
{
    public class FlushScore : ICardScoreCalculator
    {
        private readonly ISetValidator validator;

        public CardSetScore Score(CardSet set)
        {
            bool isValid
                = validator.Validate(set);

            if (isValid)
                return new CardSetScore(Name);

            return new CardSetScore(Name, 5);
        }

        public string Name => "Flush";
    }
}