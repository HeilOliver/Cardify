using Cardify.Logic.Types;

namespace Cardify.Logic.Test
{
    public class CardTestBase
    {
        protected Card GenerateCard(CardValue value, CardColor color = CardColor.Coin)
        {
            return new Card(color, value);
        }
    }
}