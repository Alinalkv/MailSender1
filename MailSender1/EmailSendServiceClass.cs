using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace MailSender1
{
    public static class MailSenderInformation
    {
       public static string Server = "smtp.yandex.ru";
       public static int Port = 25;
        public static string Addressfrom = "@yandex.ru";
    }

    public class EmailSendServiceClass
    {
        public string name;
        public System.Security.SecureString password;
        public string subject;
        public string body;
        public string toUser;


        /// <summary>
        /// Конструктор класса EmailSendServiceClass
        /// </summary>
        public EmailSendServiceClass(string name, System.Security.SecureString password, string subject, string body, string toUser)
        {
            this.name = name;
            this.password = password;
            this.subject = subject;
            this.body = body;
            this.toUser = toUser;
        }

        public void SendMessage()
        {
            string from = name + MailSenderInformation.Addressfrom;

                using (System.Net.Mail.MailMessage msg = new MailMessage(from, toUser))
                {
                    msg.Subject = subject;
                    msg.Body = body;
                    msg.IsBodyHtml = false;

                    using (System.Net.Mail.SmtpClient client = new SmtpClient(MailSenderInformation.Server, MailSenderInformation.Port))
                    {
                        client.EnableSsl = true;
                        client.Credentials = new NetworkCredential(name, password);
                        client.Send(msg);
                    }

                }

        }
    }
}
