using Cardify.Logic.Types;

namespace Cardify.Logic.CardScores.Validators
{
    public interface ISetValidator
    {
        bool Validate(CardSet set);
    }
}