using Cardify.Logic.Types;

namespace Cardify.Logic
{
    public interface ICardScoreCalculator
    {
        CardSetScore Score(CardSet set);
    }

    public class CardSetScore
    {
        public CardSetScore(bool isValid, int score = -1)
        {
            IsValid = isValid;
            Score = score;
        }

        public bool IsValid { get; }

        public int Score { get; }
    }
}