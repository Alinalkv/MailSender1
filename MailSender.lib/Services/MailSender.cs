using MailSender.lib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.lib.Services
{

    public class MailSender
    {

        private Server _Server;


        public MailSender(Server Server)
        {
            _Server = Server;
        }

        public void Send(Mail mail, Sender sender, Recipient recipient)
        {
            using (System.Net.Mail.MailMessage msg = new MailMessage(sender.Address, recipient.Address))
            {
                msg.Subject = mail.Subject;
                msg.Body = mail.Body;
                msg.IsBodyHtml = false;

                using (System.Net.Mail.SmtpClient client = new SmtpClient(_Server.Address, _Server.Port))
                {
                    client.EnableSsl = _Server.UserSSL;
                    client.Credentials = new NetworkCredential(_Server.Login, _Server.Password);
                    client.Send(msg);
                }

            }
        }

        public void Send(Mail mail, Sender sender, IEnumerable<Recipient> recipients)
        {
            foreach (var recipient in recipients)
            {
                Send(mail, sender, recipient);
            }
        }

        public void SendParallel(Mail mail, Sender sender, IEnumerable<Recipient> recipients)
        {
            foreach (var recipient in recipients)
            {
                ThreadPool.QueueUserWorkItem(_ => Send(mail, sender, recipient));
            }
        }

        //Тест
    }
}
