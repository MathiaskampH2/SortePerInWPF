using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace SortePerInWPF
{
    /// <summary>
    /// SortePer class inherits from CardGame and has the purpose of making a new SortePer game
    /// </summary>
    class SortePer : CardGame
    {
        public SortePer()
        {
            // call createDeck method from CardGame which will give me standard 52 card deck without joker
            CreateDeck();

            // loop through the cards and remove jack of spades. which makes 10 of clubs to my sorteper card.
            foreach (Card card in Cards.ToList())
            {
                if (card.CardSuit == Card.Suit.Spades && card.CardValue == (Card.Value) 10)
                {
                    this.Cards.Remove(card);
                }
            }
        }
    }
}