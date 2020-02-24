using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.lib.Services
{
    public class DebugMailSenderService : IMailSenderService
    {
        public IMailSender GetSender(Server Server) => new DebugMailSender(Server);
    }



    public class DebugMailSender: IMailSender
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

        public Task SendAsync(Mail mail, Sender sender, Recipient recipient)
        {
            Send(mail, sender, recipient);
            return Task.CompletedTask;
        }

        public Task SendAsync(Mail mail, Sender sender, IEnumerable<Recipient> recipients, CancellationToken token)
        {
            Send(mail, sender, recipients);
            return Task.CompletedTask;
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
