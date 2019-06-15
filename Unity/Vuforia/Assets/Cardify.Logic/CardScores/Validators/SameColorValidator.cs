using System.Linq;
using Cardify.Logic.Types;

namespace Cardify.Logic.CardScores.Validators
{
    public class SameColorValidator : ISetValidator
    {
        public bool Validate(CardSet set)
        {
            return set.Cards
                       .Select(card => card.Color)
                       .Distinct()
                       .Count() == 1;
        }
    }
}