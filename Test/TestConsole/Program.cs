using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Net.Mail.MailMessage msg = new MailMessage("alilykka@gmail.com", "alilykka@gmail.com");
            msg.Subject = "The Truth";
            msg.Body = "Sasha is Solnce";
            msg.IsBodyHtml = false;
            //msg.Attachments.Add()

            System.Net.Mail.SmtpClient client = new SmtpClient("smtp.yandex.ru", 25);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("UserName", "Password");

            client.Send(msg);

        }
    }
}
