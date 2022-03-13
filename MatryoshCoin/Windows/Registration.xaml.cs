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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            var user = new ADO.User();
            user.FullName = FullName.Text;
            user.Login = Login.Text;
            user.Password = PasswordData.Password;
            Classes_Blockchain.DB_Connection.connection.User.Add(user);
            Classes_Blockchain.DB_Connection.connection.SaveChanges();

            var account = new ADO.Account();
            account.Balance = 0;
            account.UserID = user.UserID;
            Classes_Blockchain.DB_Connection.connection.Account.Add(account);
            Classes_Blockchain.DB_Connection.connection.SaveChanges();
            MessageBox.Show("Пользователь и счет были созданы");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
