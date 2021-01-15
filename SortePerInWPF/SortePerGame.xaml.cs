using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SortePerInWPF
{
    /// <summary>
    /// Interaction logic for SortePerGame.xaml
    /// </summary>
    public partial class SortePerGame : Window
    {
        // new instance of game manager
        GameManager gameManager = new GameManager("", "");

        public SortePerGame(string playerName)
        {
            InitializeComponent();
            this.player0Lbl.Content = "Computer";
            this.player1Lbl.Content = playerName;
            // set the name of player 1 and player 2
            gameManager.players[0].Name = "computer";
            gameManager.players[1].Name = playerName;
            // call start method
            gameManager.Start();
            for (int i = 0; i < 1;)
            {
                // run CheckForPair when the game starts. So that we only have cards on the player hand which cant match up
                // unless we draw the corresponding card from the other player
                gameManager.CheckForPair(gameManager.players[i]);
                // bind the player 0's hand to player0Cards listView
                player0Cards.ItemsSource = gameManager.players[i].Hand;
                i++;
                gameManager.CheckForPair(gameManager.players[i]);
                // bind the player 1's hand to player1Cards listView
                player1Cards.ItemsSource = gameManager.players[i].Hand;
            }
        }

        // method that gets run whenever th event is a type of PlayerHandChangedEventArgs
        // the method refreshes both both lists of cards.
        private void OnPlayerHandChanged(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if (e is PlayerHandChangedEventArgs)
                {
                    player0Cards.ItemsSource = ((PlayerHandChangedEventArgs)e).Players[0].Hand;
                    player1Cards.ItemsSource = ((PlayerHandChangedEventArgs)e).Players[1].Hand;
                    player0Cards.Items.Refresh();
                    player1Cards.Items.Refresh();
                }
            }
            );
        }


        private void player1DrawCard_Click(object sender, RoutedEventArgs e)
        {
            gameManager.DrawCardFromPlayer(gameManager.players[1], gameManager.players[0]);
            gameManager.PlayerHandChanged += OnPlayerHandChanged;
            IsGameFinished();
        }

        private void player0DrawCard_Click(object sender, RoutedEventArgs e)
        {
            gameManager.DrawCardFromPlayer(gameManager.players[0], gameManager.players[1]);
            gameManager.PlayerHandChanged += OnPlayerHandChanged;
            IsGameFinished();
        }

        private void player1CheckForPairs_Click(object sender, RoutedEventArgs e)
        {
            gameManager.CheckForPair(gameManager.players[1]);
            gameManager.PlayerCheckPairs += OnPlayerHandChanged;
            IsGameFinished();
        }

        private void player0CheckForPair_Click(object sender, RoutedEventArgs e)
        {
            gameManager.CheckForPair(gameManager.players[0]);
            gameManager.PlayerCheckPairs += OnPlayerHandChanged;
            IsGameFinished();
        }

        public void IsGameFinished()
        {
            try
            {
                if (gameManager.IsGameFinished(gameManager.players))
                {
                    MessageBox.Show(gameManager.PlayerLostTheGame(gameManager.players), "game over",
                        MessageBoxButton.YesNo);

                    if (MessageBoxResult.Yes != MessageBoxResult.None)
                    {
                        Application.Current.Shutdown();
                        System.Windows.Forms.Application.Restart();
                    }

                    if (MessageBoxResult.No != MessageBoxResult.None)
                    {
                        Application.Current.Shutdown();
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
