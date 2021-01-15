using System;
using System.Collections.Generic;
using System.Windows;

namespace SortePerInWPF
{
    /// <summary>
    /// PlayerHandChangedEventArgs inherits from EventArgs
    /// has the purpose of making a new event 
    /// </summary>
    public class PlayerHandChangedEventArgs :EventArgs
    {
        // array of players
        public Player[] Players { get; set; }

        public PlayerHandChangedEventArgs(Player [] players)
        {
            this.Players = players;
        }
    }
}