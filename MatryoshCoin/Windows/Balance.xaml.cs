using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;


namespace MatryoshCoin.Windows
{
    /// <summary>
    /// Логика взаимодействия для Balance.xaml
    /// </summary>
    public partial class Balance : Window
    {
        private string balance = "0";

        private string ID = "0";
        int id = 0;
        ADO.Account user_cash = null;
        public static ObservableCollection<ADO.Account> accounts { get; set; }
        public Balance()
        {
            InitializeComponent();
            id = Classes_Blockchain.user_info.id_user;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Operations operations = new Operations();
            operations.Show();
            this.Close();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            ADO.Account user_cash = (Classes_Blockchain.DB_Connection.connection.Account.Where(a => a.UserID == id).FirstOrDefault());
            balance = user_cash.Balance.ToString();
            ID = id.ToString();
            
            Account.Text = "Ваш ID: " + ID;
            BalanceInfo.Text = "Ваш баланс: " + balance;
        }
    }
}
