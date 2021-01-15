namespace SortePerInWPF
{
    /// <summary>
    /// Class Card
    /// Has the purpose of making a playing card with a color, suit and a value
    /// </summary>
    public class Card
    {
        public enum Color
        {
            Red,
            Black
        }

        public enum Suit
        {
            Hearts = 1,
            Diamonds = 2,
            Clubs = 3,
            Spades = 4
        }

        public enum Value
        {
            Two = 1,
            Three = 2,
            Four = 3,
            Five = 4,
            Six = 5,
            Seven = 6,
            Eight = 7,
            Nine = 8,
            Ten = 9,
            Jack = 10,
            Queen = 11,
            King = 12,
            Ace = 13
        }

        private Suit cardSuit;

        public Suit CardSuit
        {
            get { return cardSuit; }
            set { cardSuit = value; }
        }


        private Value cardValue;

        public Value CardValue
        {
            get { return cardValue; }
            set { cardValue = value; }
        }

        private Color cardColor;

        public Color CardColor
        {
            get { return cardColor; }
            set { cardColor = value; }
        }


        public override string ToString()
        {
            return
                cardValue + " of " + cardSuit;
        }


        public Card(int suit, int value)
        {
            this.cardSuit = (Suit) suit;
            this.cardValue = (Value) value;

            if (cardSuit == Suit.Spades || cardSuit == Suit.Clubs)
            {
                this.cardColor = Color.Black;
            }
            else
            {
                this.cardColor = Color.Red;
            }
        }
    }
}