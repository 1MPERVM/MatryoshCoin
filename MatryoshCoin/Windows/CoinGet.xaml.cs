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
using System.IO;
using System.Collections.ObjectModel;

namespace MatryoshCoin.Windows
{
    /// <summary>
    /// Логика взаимодействия для CoinGet.xaml
    /// </summary>
    public partial class CoinGet : Window
    {
        public static ObservableCollection<ADO.Account> accounts { get; set; }

        public CoinGet()
        {
            InitializeComponent();
        }

        private void Transfer_Click(object sender, RoutedEventArgs e)
        {
            ADO.Account user_cash = (Classes_Blockchain.DB_Connection.connection.Account.Where(a => a.UserID == Classes_Blockchain.user_info.id_user).FirstOrDefault());

            string[] lines = File.ReadAllLines(@"C:\Program Files\MatryoshTransfer.txt");
            string sumForGet = lines[lines.Length - 1];
            string secretPhrase = lines.Last();
            if (SecretCode.Text == secretPhrase)
            {
                MessageBox.Show("Транзакция проведена успешно");
            }
            else
            {
                user_cash.Balance -= Convert.ToDouble(sumForGet);
                Classes_Blockchain.DB_Connection.connection.SaveChanges();
                MessageBox.Show("Ошибка");

            }
        }
        

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Operations operations = new Operations();
            operations.Show();
            this.Close();
        }
    }
}
