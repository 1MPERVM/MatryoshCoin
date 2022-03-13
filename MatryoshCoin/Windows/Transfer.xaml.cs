using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRCoder;
using System.Windows;
using System.Drawing;
using System.Collections.ObjectModel;
using System.IO;


namespace MatryoshCoin.Windows
{
    /// <summary>
    /// Логика взаимодействия для Transfer.xaml
    /// </summary>
    public partial class Transfer : Window
    {
        public static ObservableCollection<ADO.Account> account { get; set; }
        public static ObservableCollection<ADO.Calculation> calculations { get; set; }

        private readonly string qrCodePath = @"C:\Users\Impervm\Desktop\secretPhrase.bmp";

        private string secretCode;
        public Transfer()
        {
            InitializeComponent();
        }

        private void Transfer_Click(object sender, RoutedEventArgs e)
        {
            var transaction = new ADO.Transaction();
            
            var calc = new ADO.Calculation();
            
            account = new ObservableCollection<ADO.Account>(Classes_Blockchain.DB_Connection.connection.Account.ToList());

            calculations = new ObservableCollection<ADO.Calculation>(Classes_Blockchain.DB_Connection.connection.Calculation.ToList());
            
            var accountSender = account.Where(a => a.UserID == Classes_Blockchain.user_info.id_user).FirstOrDefault();
            
            var accountGetter = account.Where(a => a.UserID == Convert.ToInt32(IdGetter.Text)).FirstOrDefault();
            
            var calculationsForSend = calculations.Where(a => a.AccountID == accountSender.AccountID).FirstOrDefault();
            
            if (accountSender != null)
            {
                if (Convert.ToDouble(Sum.Text) > 0 && IdGetter.Text != null && accountSender.Balance >= Convert.ToDouble(Sum.Text))
                {
                    QRCodeGeneration();
                    HideInformation();

                    accountGetter.Balance += Convert.ToDouble(Sum.Text);
                    accountSender.Balance -= Convert.ToDouble(Sum.Text);
                    transaction.SenderID = Classes_Blockchain.user_info.id_user;
                    transaction.RecipientID = Convert.ToInt32(IdGetter.Text);
                    transaction.QR_code = qrCodePath;
                    calc.AccountID = accountGetter.AccountID;
                    calc.Result = calculationsForSend.Result;
                    Classes_Blockchain.DB_Connection.connection.Calculation.Add(calc);
                    Classes_Blockchain.DB_Connection.connection.SaveChanges();
                    Classes_Blockchain.DB_Connection.connection.Calculation.Remove(calculationsForSend);
                    Classes_Blockchain.DB_Connection.connection.SaveChanges();  




                    Classes_Blockchain.DB_Connection.connection.Transaction.Add(transaction);
                    MessageBox.Show("QRcode с секретной фразой был сгенерирован.");
                    Classes_Blockchain.DB_Connection.connection.SaveChanges();

                }
                else
                {
                    MessageBox.Show("Ошибка!\nПроверьте баланс.");
                }


            }

        }

        private void QRCodeGeneration()
        {
            secretCode = SecretPhraseGeneration();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(secretCode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            qrCodeImage.Save($"{qrCodePath}");

        }

        private string SecretPhraseGeneration()
        {
            Random random = new Random();
            int length = 6;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void HideInformation()
        {
            string hidenInf = secretCode;
            string sumForTransfer = Sum.Text;

            string secretPath = @"C:\Program Files\MatryoshTransfer.txt";
            

            using (StreamWriter sw = new StreamWriter(secretPath, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(sumForTransfer);
                sw.WriteLine(hidenInf);
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
