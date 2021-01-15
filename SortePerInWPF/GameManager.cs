using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SortePerInWPF
{
    /// <summary>
    /// Class GameManager
    /// Has the purpose of controlling the sortePer game
    /// </summary>
    class GameManager
    {
        // instance of cardGame class
        private CardGame cardGame;
        // array of players
        public Player[] players = new Player[2];
        // event that gets triggered when a player checks for pair
        public event EventHandler PlayerCheckPairs;
        // event that gets triggered when a players hand i changed
        public event EventHandler PlayerHandChanged;
        // constructor that makes a new sortePer and two new players
        public GameManager(string player0Name, string player1Name)
        {
            cardGame = new SortePer();
            players[0] = new Player(new List<Card>(), player0Name);
            players[1] = new Player(new List<Card>(), player1Name);
        }

        // start method that shuffes the deck that cardGame makes, and deals the card out equally between the 2 players.
        public void Start()
        {
            ShuffleDeck(cardGame.Cards);
            DealCardsToPlayers();
        }

        // shuffle method randomizes the card deck
        public void ShuffleDeck<T>(IList<T> list)
        {
            Random random = new Random();

            for (int i = list.Count - 1; i > 1; i--)
            {
                int ran = random.Next(i + 1);
                T value = list[ran];
                list[ran] = list[i];
                list[i] = value;
            }
        }

        // method checks if one of the players has 1 card left and if that card is jack of clubs then they have lost the game
        public string PlayerLostTheGame(Player[] players)
        {
            string lost = null;
            if (players[0].Hand.Count == 1 && players[0].Hand.First().CardValue == Card.Value.Jack &&
                players[0].Hand.First().CardSuit == Card.Suit.Clubs)
            {
                lost = this.players[0].Name +" has lost" + "\n" + "Would you like to play again?";
            }
            else if (players[1].Hand.Count == 1 && players[1].Hand.First().CardValue == Card.Value.Jack &&
                     players[1].Hand.First().CardSuit == Card.Suit.Clubs)

            {
                lost = this.players[1].Name + " has lost" + "\n" + "Would you like to play again?";
                
            }

            return lost;
        }

        // method checks if the game is finished by checking if any of the players has 1 card left
        public bool IsGameFinished(Player[] players)
        {
            if (players[0].Hand.Count == 0 && players[1].Hand.Count == 1)
            {
                return true;
            }

            else if (players[1].Hand.Count == 0 && players[0].Hand.Count == 1)
            {
                return true;
            }

            return false;
        }

        // method deals cards out from the shuffled deck to the players
        public void DealCardsToPlayers()
        {
            while (cardGame.Cards.Count != 0)
            {
                foreach (Player player in players.ToList())
                {
                    if (cardGame.Cards.Count == 0)
                    {
                        return;
                    }

                    player.DrawFromDeck(cardGame.Cards.First());
                    cardGame.Cards.RemoveAt(index: 0);
                }
            }
        }

        // method draws a random card object from the other player
        public void DrawCardFromPlayer(Player playerTo, Player playerFrom)
        {
            Random rand = new Random();
            // make a new random number between 0 and playerFrom.hand.count
            int rnd = rand.Next(0, playerFrom.Hand.Count());
            // store the select card in a temporary card, so we know which card to move and remove
            Card selectedCard = playerFrom.Hand.ElementAt(rnd);
            // remove the selectedCard from playerFrom.hand
            playerFrom.Hand.Remove(selectedCard);
            // add the selectedCard to playerTo.hand
            playerTo.Hand.Add(selectedCard);
            // invoke the playerHandChanged event
            PlayerHandChanged?.Invoke(this, new PlayerHandChangedEventArgs(players));
            Debug.WriteLine(playerTo + " took " + selectedCard.ToString());
        }

        // method checkForPair, checks if theres 2 black cards of same value on the same hand. then it removes the card
        public void CheckForPair(Player player)
        {
            for (int i = 0; i < player.Hand.Count; i++)
            {
                foreach (Card card in player.Hand.ToList())
                {
                    if (card.CardValue == player.Hand[i].CardValue && card.CardSuit != player.Hand[i].CardSuit)
                    {
                        if (card.CardColor == player.Hand[i].CardColor)
                        {
                            // store the card that we found from for loop in a temporary card so we know which card to be removed
                            Card cardToBeRemoved = player.Hand[i];
                            Debug.WriteLine(player.Name + " parried " + card.ToString() + " with " + player.Hand[i].ToString());
                            // remove the card that my foreach loop found
                            player.Hand.Remove(card);
                            // remove the card that my for loop found 
                            player.Hand.Remove(cardToBeRemoved);
                            // invoke playerCheckpairs event
                            PlayerCheckPairs?.Invoke(this, new PlayerHandChangedEventArgs(players));
                        }
                    }
                }
            }
        }
    }
}