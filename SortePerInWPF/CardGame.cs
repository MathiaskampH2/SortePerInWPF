using System.Collections.Generic;
using System.Linq;

namespace SortePerInWPF
{
    /// <summary>
    /// Abstract class CardGame
    /// Has the purpose of making a 52 card deck without joker
    /// </summary>
    abstract class CardGame
    {
        // list of Cards 
        List<Card> cards = new List<Card>();
        public List<Card> Cards { get { return cards; } }

        // create a standard deck of 52 cards, without joker and add them to the list of Cards
        public virtual void CreateDeck()
        {
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    Cards.Add(new Card(i, j));
                }
            }
        }
    }
}