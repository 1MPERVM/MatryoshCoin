using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Collections.ObjectModel;


namespace MatryoshCoin.Windows
{
    /// <summary>
    /// Логика взаимодействия для Mining.xaml
    /// </summary>
    public partial class Mining : Window
    {
        private double balance;
        private List<string> hashesToDecode = new List<string>();
        private int _inWork = 0;
        private List<string> brootedHashes = new List<string>();
        private int accId;
  
        public static ObservableCollection<ADO.Account> accounts { get; set; }

        public Mining()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            MiningInvoke();
        }
        private async void MiningInvoke()
        {
            _inWork = 0;
            await Task.Run(() => MiningStart());
        }
        public void MiningStart()
        {
            string phrase = "";
            while (_inWork == 0)
            {
                for (int i = 0; i < 100; i++)
                {
                    Classes_Blockchain.Matreshka matreshka = new Classes_Blockchain.Matreshka();
                    phrase = SHA256Hashing(matreshka.Phrase);
                    Console.WriteLine(phrase);
                    hashesToDecode.Add(phrase);
                }
                    
                    
                
                TryToDecodePhrase();
                MessageBox.Show(balance.ToString());

                if (_inWork == 1)
                {
                    break;
                }
            }
        }

        private string SHA256Hashing(string word)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(word);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }

            return hashString;
        }

        private string PhrasesForDecoding()
        {
            char[] letters = "M@TrE5KA".ToCharArray();

            Random rand = new Random();
            List<char> tempWord = new List<char>();
            for (int i = 0; tempWord.Count != letters.Length; i++)
            {

                int letter_num = rand.Next(0, letters.Length);

                if (tempWord.Contains(letters[letter_num]))
                {
                    i++;
                }
                else
                {
                    tempWord.Add(letters[letter_num]);
                }
            }

            var finalWord = new string(tempWord.ToArray());

            return SHA256Hashing(finalWord);
        }

        private void TryToDecodePhrase()
        {
            string wordForBroot = PhrasesForDecoding();

            foreach (var item in hashesToDecode)
            {
                if (item == wordForBroot)
                {
                    if (brootedHashes.Contains(item))
                    {
                        
                        balance += 0.00001;
                    }
                    else
                    {
                        balance += 0;
                        brootedHashes.Add(item);
                    }

                }

            }
        }
        

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            
            _inWork = 1;
            var acc = Classes_Blockchain.DB_Connection.connection.Account.Where(b => b.UserID == Classes_Blockchain.user_info.id_user).FirstOrDefault();
            acc.Balance += balance;
            accId = acc.AccountID;
            var calculations = new ADO.Calculation();
            calculations.AccountID = accId;
            foreach (var item in brootedHashes)
            {
                calculations.Result = item;
                Classes_Blockchain.DB_Connection.connection.Calculation.Add(calculations);
            }
            
            Classes_Blockchain.DB_Connection.connection.SaveChanges();
               

        }
        

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Operations operations = new Operations();
            operations.Show();
            this.Close();
        }
    }
    
}
