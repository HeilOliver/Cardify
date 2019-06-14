namespace Cardify.Logic
{
    public class CardScore
    {
        public string Name { get; }
        public int Score { get; }

        public CardScore(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }
}