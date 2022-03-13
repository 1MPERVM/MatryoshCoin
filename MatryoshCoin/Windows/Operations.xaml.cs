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

namespace MatryoshCoin.Windows
{
    /// <summary>
    /// Логика взаимодействия для Operations.xaml
    /// </summary>
    public partial class Operations : Window
    {
        
        public Operations()
        {
            InitializeComponent();
         
        }

        private void StartMining_Click(object sender, RoutedEventArgs e)
        {
            Mining mining = new Mining();
            mining.Show();
            this.Close();
        }

        private void ShowBalance_Click(object sender, RoutedEventArgs e)
        {
            Balance balance = new Balance();
            balance.Show();
            this.Close();
        }

        private void MatryoshCoinTransfer_Click(object sender, RoutedEventArgs e)
        {
            Transfer transfer = new Transfer();
            transfer.Show();
            this.Close();
        }

        private void GetMatryoshCoin_Click(object sender, RoutedEventArgs e)
        {
            CoinGet coinGet = new CoinGet();
            coinGet.Show();
            this.Close();
        }
    }
}
