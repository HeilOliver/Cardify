using System.Collections.Generic;

namespace Cardify.Logic.Types
{
    public class Card
    {
        public Card(CardColor color, CardValue value)
        {
            Color = color;
            Value = value;
        }

        public CardColor Color { get; }

        public CardValue Value { get; }

        protected bool Equals(Card other)
        {
            return Color == other.Color && Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Card) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) Color * 397) ^ (int) Value;
            }
        }
    }
}