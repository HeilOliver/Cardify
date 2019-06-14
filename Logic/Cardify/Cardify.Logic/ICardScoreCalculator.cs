using Cardify.Logic.Types;

namespace Cardify.Logic
{
    public interface ICardScoreCalculator
    {
        CardSetScore Score(CardSet set);

        string Name { get; }
    }

    public class CardSetScore
    {

        public CardSetScore(string name, int score)
        {
            Score = score;
            Name = name;
        }

        public CardSetScore(string name)
        {
            Score = -1;
            Name = name;
        }

        public bool IsValid => Score != -1;

        public int Score { get; }

        public string Name { get; }
    }
}