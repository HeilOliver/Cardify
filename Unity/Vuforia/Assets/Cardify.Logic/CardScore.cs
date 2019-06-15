namespace Cardify.Logic
{
    public class CardScore
    {
        public string Name { get; }
        public int Score { get; }

        public string Cards { get; }

        public CardScore(string name, int score, string cards)
        {
            Name = name;
            Score = score;
            Cards = cards;
        }
    }
}