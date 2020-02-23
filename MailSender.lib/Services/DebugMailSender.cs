using MailSender.lib.Entities;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace MailSender.lib.Services
{
    public class DebugMailSender
    {

        private Server _Server;


        public DebugMailSender(Server Server)
        {
            _Server = Server;
        }

        public void Send(Mail mail, Sender sender, Recipient recipient)
        {
            Debug.WriteLine("Отправка почты от {0} к {1} через {2}:{3}[{4}]/n{5}:{6}",
                sender.Address, recipient.Address, _Server.Address, _Server.Port, _Server.UserSSL ? "SSL" : "no SSL", mail.Subject, mail.Body);
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
    }
}
