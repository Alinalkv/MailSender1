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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;
using MailSender.lib.Entities;
using MailSender.lib.Services;
using MailSender.lib.Service;
using MailSender.lib.Data;

namespace MailSender1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (var db = new MailSenderDBContext())
            {
               db.Database.Log = Console.WriteLine;

                foreach (var item in db.RecipientDBs)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }

        private void OnButtonClickSendMail(object sender, RoutedEventArgs e)
        {
            //перестало работать, когда унесла view
            //var recipient = RecipientsList.SelectedItem as Recipient;
            //var server = ServersList.SelectedItem as Server;
            //var senderUser = SendersList.SelectedItem as Sender;

            //if (recipient is null || server is null || senderUser is null) return;

            //var mailSender = new MailSender.lib.Services.DebugMailSender(server.Address, server.Port, server.UserSSL, server.Login, server.Password.Decode());
            //mailSender.Send(Subject.Text, Body.Text, senderUser.Address, recipient.Address);
        }

        private void OnClickSenderEdit(object sender, RoutedEventArgs e)
        {
            var senderChosen = SendersList.SelectedItem as Sender;
            if (sender is null) return;

            var dialog = new SenderEditor(senderChosen);
            if (dialog.ShowDialog() != true) return;

            senderChosen.Name = dialog.NameValue;
            senderChosen.Address = dialog.AddressValue;
        }
    }
}
