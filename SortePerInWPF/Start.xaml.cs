using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Window
    {
        public Start()
        {
            InitializeComponent();
            HeadLine.FontSize = 35;
            // default value of textBoxName
            TextBoxName.Text = "Player";
          
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // hide start window
            Visibility = Visibility.Hidden;
            // new instance of SortePerGame and i send my textBoxName with it as parameter
            SortePerGame sortePerGame = new SortePerGame(TextBoxName.Text.ToString());
            // show the sortePerGame window
            sortePerGame.Show();
        }
    }
}
