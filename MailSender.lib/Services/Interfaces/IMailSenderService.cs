using MailSender.lib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.lib.Services.Interfaces
{
    public interface IMailSenderService
    {
        IMailSender GetSender(Server Server);
    }

    public interface IMailSender
    {
        void Send(Mail mail, Sender sender, Recipient recipient);
        void Send(Mail mail, Sender sender, IEnumerable<Recipient> recipients);
        Task SendAsync(Mail mail, Sender sender, Recipient recipient);
        Task SendAsync(Mail mail, Sender sender, IEnumerable<Recipient> recipients, CancellationToken token);

    }
}
