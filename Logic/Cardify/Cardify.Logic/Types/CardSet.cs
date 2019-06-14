using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Cardify.Logic.Types
{
    public class CardSet
    {
        private readonly ISet<Card> cards;

        public CardSet(ICollection<Card> cards)
        {
            this.cards = new HashSet<Card>(cards);
        }

        public CardSet()
        {
            cards = new HashSet<Card>();
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public IReadOnlyCollection<Card> Cards => new ReadOnlyCollection<Card>(cards.ToList());
    }
}