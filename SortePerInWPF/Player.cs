using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace SortePerInWPF
{
    /// <summary>
    /// Class player has the purpose of making a new object of a player
    /// it has a name and a list of cards
    /// </summary>
    public class Player
    {
        // list of cards which will represents the players Hand
        public List<Card> Hand { get; set; }

        public string Name { get; set; }


        public Player(List<Card> hand, string name)
        {
            this.Hand = hand;
            this.Name = name;
        }

        // drawFromDeck method is used by gameManager to take a card from the shuffled deck and add it to the players Hand
        public void DrawFromDeck(Card card)
        {
            Hand.Add(card);
        }
    }
}