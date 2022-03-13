using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;


namespace MatryoshCoin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<ADO.User> users { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            users = new ObservableCollection<ADO.User>(Classes_Blockchain.DB_Connection.connection.User.ToList());
            var userFind = users.Where(a => a.Login == LoginData.Text && a.Password == PasswordData.Password).FirstOrDefault();
            if (userFind != null)
            {
                MessageBox.Show($"Добро пожаловать, {userFind.FullName}");
                Windows.Operations operation = new Windows.Operations();
                Classes_Blockchain.user_info.id_user = userFind.UserID;
                Classes_Blockchain.user_info.name_user = userFind.FullName;


                operation.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Логин или пароль неверные", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            Windows.Registration registration = new Windows.Registration();
            registration.Show();
            this.Close();

        }


    }
}
