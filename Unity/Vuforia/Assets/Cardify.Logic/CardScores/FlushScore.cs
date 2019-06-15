using System.Linq;
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
            var dictionary = set.Cards
                .GroupBy(card => card.Color, card => card)
                .ToDictionary(key => key.Key, val => val.ToList());

            bool isValid = dictionary.Values.Any(collection => collection.Count>= 5);

            if (isValid)
                return new CardSetScore(Name, 6);

            return new CardSetScore(Name);
        }

        public string Name => "Flush";
    }
}