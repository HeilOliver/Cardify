using Cardify.Logic.Types;

namespace Cardify.Logic
{
    public interface ICardScoreCalculator
    {
        CardSetScore Score(CardSet set);

        string Name { get; }
    }
}